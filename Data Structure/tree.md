### 트리(Tree)

트리는 그래프의 종류로, 사이클이 없는 계층적 구조의 자료구조이다.

노드(Node)와 간선(Edge)으로 구성되며, 부모 - 자식 관계를 가진다.

##### 

트리 = 사이클 없는 그래프 + 계층 구조



### 트리의 특징

루트 노드(Root)가 존재하낟.

사이클이 없다.

부모 - 자식 관계를 가진다.

N개의 노드는 N - 1개의 간선을 가진다.

하나의 노드에서 여러 자식 노드를 가질 수 있다.



### 트리 용어

##### 기본 용어

루트 (Root) : 트리의 시작 노드

리프 (Leaf) : 자식이 없는 노드

부모 (Parent) / 자식 (Child)

형제 (Sibling) : 같은 부모를 가진 노드

레벨 (Level) : 트리의 특정 깊이를 가지는 노드의 집합



##### 깊이 vs 높이

###### 깊이 (Depth)

루트에서 해당 노드까지의 거리 ( 간선의 수)



###### 높이(Height)

해당 노드에서 가장 깊은 리프까지의 거리



### 트리의 종류

##### 일반트리(General Tree)

계층에 대한 제한이 없는 트리, 즉 둘 이상의 자식 노드를 가질 수 있다.



##### 이진트리(Bunary Tree)

자식 노드의 개수가 최대 2개인 트리



##### 전 이진트리(Full Binary Tree)

모든 노드가 0개 또는 2개의 자식 노드를 갖는 트리



##### 완전 이진트리(Complete Binary Tree)

마지막 레벨을 제외하고 모두 꽉 차있는 트리

마지막 레벨은 왼쪽 부터 채워짐



##### 포화 이진트리(Perfect Binary Tree)

전 이진트리이면서 완전 이진트리인 경우로, 모든 말단 노드는 같은 높이에 있어야하며,

모든 레벨이 꽉차 있는 트리

트리의 높이가 k일때, 노드의 개수가 정확히 2^k - 1개여야 한다.



##### 이진탐색트리(Binary Search Tree)

모든 노드 n이 왼쪽 자식들 < n < 모든 오른쪽 자식들을 만족하는 이진트리



### 균형 트리 vs 비균형 트리



##### 균형 트리 

높이 logN

탐색 O(logN)



예를 들어 레드-블랙 트리, avl 트리



##### 비균형 트리

한쪽으로 쏠린 트리 -> Linked List 형태

O(N)



### 트리의 핵심

트리 = 재귀 구조

모든 트리 알고리즘은 재귀로 풀린다.



### 순회

##### DFS 기반

###### 전위 순회 (Preorder)

루트 -> 왼쪽 -> 오른쪽



###### 중위 순회 (Inorder)

왼쪽 -> 루트 -> 오른쪽



###### 후위 순회 (Postorder)

왼쪽 -> 오른쪽 -> 루트



##### BFS (Level Order)

레벨 순서대로 탐색 (Queue 사용)



### 트리 vs 그래프 차이

| 구분   	| 트리  	| 그래프 	|

| ---- 		| --- 		| --- 		|

| 사이클  	| 없음  	| 있음  	|

| 루트   	| 있음  	| 없음  	|

| 간선 수 	| N-1 		| 자유  	|

| 구조   	| 계층  	| 관계  	|





### 코드

// 연결 리스트 || 트리

class Node

{

public:

&#x20;   Node(int data) : data(data) { }



public:

&#x20;   Node\* next = nullptr;

&#x20;   Node\* prev = nullptr;

&#x20;   int data;



};





class Node

{

public:

&#x20;   Node(const char\* data) : data(data) { }



public:

&#x20;   const char\* data;

&#x20;   vector<Node\*> children;

};



Node\* CreateTree()

{

&#x20;   Node\* root = new Node("R1 개발실");



&#x20;   {

&#x20;       Node\* node = new Node("디자인팀");

&#x20;       root->children.push\_back(node);

&#x20;       {

&#x20;           Node\* leaf = new Node("전투");

&#x20;           node->children.push\_back(leaf);

&#x20;       }

&#x20;       {

&#x20;           Node\* leaf = new Node("경제");

&#x20;           node->children.push\_back(leaf);

&#x20;       }

&#x20;       {

&#x20;           Node\* leaf = new Node("스토리");

&#x20;           node->children.push\_back(leaf);

&#x20;       }

&#x20;   }

&#x20;   {

&#x20;       Node\* node = new Node("프로그래밍팀");

&#x20;       root->children.push\_back(node);

&#x20;       {

&#x20;           Node\* leaf = new Node("클라");

&#x20;           node->children.push\_back(leaf);

&#x20;       }

&#x20;       {

&#x20;           Node\* leaf = new Node("서버");

&#x20;           node->children.push\_back(leaf);

&#x20;       }

&#x20;       {

&#x20;           Node\* leaf = new Node("엔진");

&#x20;           node->children.push\_back(leaf);

&#x20;       }

&#x20;   }

&#x20;   {

&#x20;       Node\* node = new Node("아트팀");

&#x20;       root->children.push\_back(node);

&#x20;       {

&#x20;           Node\* leaf = new Node("캐릭터");

&#x20;           node->children.push\_back(leaf);

&#x20;       }

&#x20;       {

&#x20;           Node\* leaf = new Node("배경");

&#x20;           node->children.push\_back(leaf);

&#x20;       }

&#x20;   }





&#x20;   return root;

}

// 깊이 (depth) : 루트에서 어떤 노드에 도달하기 위해 거쳐야하는 간선의 개수

void PrintTree(Node\* root, int depth = 0)

{

&#x20;   for (int i = 0; i < depth; i++)

&#x20;       cout << "-";

&#x20;   cout << root->data << endl;



&#x20;   int size = root->children.size();

&#x20;   for (int i = 0; i < size; i++)

&#x20;   {

&#x20;       Node\* node = root->children\[i];

&#x20;       PrintTree(node, depth + 1);

&#x20;   }

}



// 높이

int GetHeight(Node\* root)

{

&#x20;   int ret = 1;



&#x20;   int size = root->children.size();

&#x20;   for (int i = 0; i < size; i++)

&#x20;   {

&#x20;       Node\* node = root->children\[i];

&#x20;       int h = GetHeight(node) + 1;



&#x20;       if (ret < h)

&#x20;           ret = h;

&#x20;   }



&#x20;   return ret;

}



int main()

{

&#x20;   Node\* root = CreateTree();



&#x20;   PrintTree(root);



&#x20;   int h = GetHeight(root);

&#x20;   cout << h;



&#x20;   /\*Node\* n1 = new Node(1);

&#x20;   Node\* n2 = new Node(2);

&#x20;   Node\* n3 = new Node(3);

&#x20;   Node\* n4 = new Node(4);

&#x20;   Node\* n5 = new Node(5);



&#x20;   //\[1]<->\[2]<->\[3]<->\[4]<->\[5]

&#x20;   //\[head]               \[tail]

&#x20;   n1->next = n2;

&#x20;   n2->prev = n1;



&#x20;   n2->next = n3;

&#x20;   n3->prev = n2;



&#x20;   n3->next = n4;

&#x20;   n4->prev = n3;



&#x20;   n4->next = n5;

&#x20;   n5->prev = n4;



&#x20;   Node\* head = n1;

&#x20;   Node\* tail = n5;

}



### 정리

트리는 사이클이 없는 계층 구조의 그래프로,

부모-자식 관계를 가지며 재귀적인 구조를 통해 탐색과 연산이 이루어진다.

