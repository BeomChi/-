### 이진 탐색 트리(Binary Search Tree)

이진 탐색트리(BST)는 이진 트리의 일종으로, 정렬된 구조를 유지하는 트리이다.

```

왼쪽 서브트리 < 현재 노드 < 오른쪽 서브 트리

```

이러한 규칙을 만족하고

왼쪽 서브트리도 BST이고

오른쪽 서브트리도 BST이다.



### 특징

이진 트리(자식이 최대 2개)

정렬된 구조 유지

중복 키 허용하지 않음(일반적인 경우)

탐색 / 삽입 / 삭제가 효율적



### 시간 복잡도

|연산|평균|최악|
|-|-|-|
|검색|O(log N)|O(N)|
|삽입|O(log N)|O(N)|
|삭제|O(log N)|O(N)|



최악의 경우가 저런 이유는

트리가 한쪽으로 쏠리면 연결리스트(Linked List) 형태가 되어버려서 이다.



### 핵심 성질

중위 순회(Inoder Traversal)

```

왼쪽 -> 루트 -> 오른쪽

```

결과로는 오름차순 정렬이 된다.



### 탐색(Search)

루트에서 시작한다.

검색 값을 루트와 비교한다. 루트보다 작으면 왼쪽으로, 크다면 오른쪽으로 재귀호출한다.

일치하는 값을 찾을 때까지 절차를 반복한다.

검색 값이 없으면 null을 반환한다.



##### 재귀함수 버전

```

Node\* Search(const Node\* root, const T\& data)

{

&#x09;if (root == nullptr || root->data == data)

&#x09;	return root;



&#x09;if (root->\_data < data)

&#x09;	return Search(root->\_right, data);



&#x09;return Search(root->\_left, data);

}

```



##### 함수버전

```

Node\* Search(const T\& data)

{

&#x09;Node\* current = \_root;



&#x09;if (current == nullptr)

&#x09;	return nullptr;



&#x09;while (current != nullptr)

&#x09;{

&#x09;	if (current->\_data == data)

&#x09;		return current;



&#x09;	if (current->\_data < data)

&#x09;		current = current->\_right;

&#x09;	else

&#x09;		current = current->\_left;

&#x09;}



&#x09;return nullptr;

}

```



### 삽입

이진 탐색 트리에 데이터를 삽입하는 작업을 말한다.

Root에서 시작한다.

삽입 값을 루트와 비교하고 루트보다 작으면 왼쪽, 크면 오른쪽으로 들어간다.

리프 노드에 도달한 후 노드보다 크다면 오른쪽에 작다면 왼쪽에 삽입한다.



##### 재귀함수 버전

```

Node\* Insert(Node\* root, const T\& data)

{

&#x09;if (root == nullptr)

&#x09;	return new Node<T>(data);



&#x09;if (root->\_data < data)

&#x09;	root->\_right = Insert(root->\_right, data);

&#x09;else

&#x09;	root->\_left = Insert(root->\_left, data);



&#x09;return root;

}

```



##### 반복문 버전

```

void Insert(const T\& data)

{

&#x09;if (\_root == nullptr)

&#x09;{

&#x09;	\_root = new Node<T>(data);

&#x09;	return;

&#x09;}



&#x09;Node\* parent = nullptr;

&#x09;Node\* current = \_root;



&#x09;while (current != nullptr)

&#x09;{

&#x09;	parent = current;



&#x09;	if (current->\_data < data)

&#x09;		current = current->\_right;

&#x09;	else

&#x09;		current = current->\_left;

&#x09;}



&#x09;if (parent->\_data < data)

&#x09;	parent->\_right = new Node<T>(data);

&#x09;else

&#x09;	parent->\_left = new Node<T>(data);



}

```



### 삭제

##### 삭제할 노드가 리프노드인 경우

노드를 삭제하기만 하면 된다.



##### 삭제할 노드에 자식이 하나만 있는 경우

노드를 삭제하고 자식 노드를 삭제된 노드의 부모에 직접 연결한다.



##### 자식이 둘 있는 경우 sucessor 노드를 찾는 과정이 추가가 된다.



###### surrcessor노드란?

right subtree에 최솟값

즉,inorder 순회에서 다음 노드를 말한다.



삭제 과정은 다음과 같다.

삭제할 노드를 찾는다.

삭제할 노드의 successor 노드를 찾는다.

삭제할 노드와 successor 노드의 값을 바꾼다.

successor 노드를 삭제한다.



```

Node\* Delete(Node\* root, const T\& data)

{

&#x20;   if (root == nullptr)

&#x20;       return nullptr;



&#x20;   if (data < root->\_data)

&#x20;       root->\_left = Delete(root->\_left, data);

&#x20;   else if (data > root->\_data)

&#x20;       root->\_right = Delete(root->\_right, data);

&#x20;   else

&#x20;   {

&#x20;       // case 1,2

&#x20;       if (root->\_left == nullptr)

&#x20;       {

&#x20;           Node\* temp = root->\_right;

&#x20;           delete root;

&#x20;           return temp;

&#x20;       }

&#x20;       else if (root->\_right == nullptr)

&#x20;       {

&#x20;           Node\* temp = root->\_left;

&#x20;           delete root;

&#x20;           return temp;

&#x20;       }



&#x20;       // case 3 (두 자식)

&#x20;       Node\* successor = root->\_right;

&#x20;       while (successor->\_left != nullptr)

&#x20;           successor = successor->\_left;



&#x20;       root->\_data = successor->\_data;

&#x20;       root->\_right = Delete(root->\_right, successor->\_data);

&#x20;   }



&#x20;   return root;

}

```



### BST의 문제점

데이터가 정렬된 상태로 들어오면 한쪽으로 치우쳐짐

그럼 탐색하는데 O(N)이라는 시간이 발생함



이거에 대한 해결 방안

균형 트리(AVL, Red-Black Tree)



### BST vs Heap

|구분|BST|Heap|
|-|-|-|
|정렬|O|X|
|탐색|빠름|느림|
|루트|중간값|최대/최소|
|목적|검색|우선순위|



### 정리

BST는 정렬된 구조를 유지하는 이진 트리로,

탐색,삽입,삭제를 평균 O(long N)에 수행할 수 있다.

