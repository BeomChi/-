### 연결 리스트 (Linked List)



연결리스트(Linked list)는 각 데이터를 노드(Node) 단위로 나누고,

포인터를 통해 서로 연결하는 자료구조이다.



배열과 달리 메모리에 연속적으로 저장되지 않는다.



데이터 + 다음 노드 주소 -> 데이터 + 다음 노드 주소 -> - - -



### 배열 vs 연결리스트

| 구분    	| 배열      	| 연결 리스트  	|

| -----------	| -----------	| -----------------	|

| 메모리   	| 연속적     	| 비연속적    	|

| 접근    	| 빠름 O(1) 	| 느림 O(n) 	|

| 삽입/삭제 | 느림 O(n) | 빠름 O(1) 		|

| 캐시 효율 	| 좋음      	| 나쁨      		|



단, 연결리스트는 삭제 및 삽입할 위치를 알고 있어야 빠르다. 아니면 순회를 돌기 때문에...



### 연결리스트 종류

##### 단일 연결리스트 (Singly Linked List)

* next 포인터만 존재
* 한 방향 이동

A -> B -> C -> D



##### 이중 연결 리스트 (Doubly Linked List)

* prev + next 존재
* 양방향 이동 가능

A <-> B <-> C <-> D



##### 원형 연결 리스트

마지막 노드가 다시 처음을 가리킴



A -> B -> C -> A

tail->next = head



### 연결 리스트 특징

* 노드는 데이터 + 포인터로 구성됨
* 삽입/ 삭제O(1)
* 특정 위치 접근 O(n)
* 메모리 추가 사용(포인터)
* 캐시 효율 낮음



### 시간 복잡도

| 연산            		| 시간   	|

| ------------- 		| ---- 		|

| 탐색            		| O(n) 	|

| 삽입 (위치 알고 있음) 	| O(1) 	|

| 삭제 (위치 알고 있음)	| O(1) 	|

위치를 알고 있으면 빠르지만, 찾는 순간 즉 탐색하는 순간 느려진다.



### 연결 리스트 핵심 패턴

##### 삽입

prev -> new -> next



##### 삭제

prev -> next



### 사용 되는 곳

* STL list
* LRU Cache
* 메모리 관리
* Undo / Redo 시스템
* 그래프 인접 리스트
* 게임 오브젝트 관리



Linked List = 노드를 포인터로 연결한 구조

삽입 / 삭제 O(1) , 탐색 O(n)



예시 코드



template<typename T>

class Node

{

&#x09;

public:

&#x09;Node(T data) : data(data), prev(nullptr), next(nullptr) { }



public:

&#x09;T data;

&#x09;Node\* prev;

&#x09;Node\* next;

};



//중간 삽입 삭제가 빠르나

//삽입이나 삭제할 위치를 기억하지 않으면(모르면) 느리게 작동하고

//서치가 들어가는 순간 느려진다.



template<typename T>

class List

{

public:

&#x09;List()

&#x09;{

&#x09;	//더미 추가

&#x09;	\_head = new Node<T>(0);

&#x09;	\_tail = new Node<T>(0);

&#x09;	\_head->next = \_tail;

&#x09;	\_tail->prev = \_head;

&#x09;}

&#x09;\~List()

&#x09;{

&#x09;	Node<T>\* node = \_head;

&#x09;	while(node)

&#x09;	{

&#x09;		Node<T>\* deleteNode = node;

&#x09;		node = node->next;



&#x09;		delete deleteNode;

&#x09;	}

&#x09;}



&#x09;Node<T>\* GetNode(int index)

&#x09;{

&#x09;	Node<T>\* node = \_head->next;

&#x09;	if (node == \_tail)

&#x09;		return nullptr;



&#x09;	for (int i = 0; i < index; i++)

&#x09;	{

&#x09;		if (node == \_tail->prev)

&#x09;			return nullptr;



&#x09;		node = node->next;

&#x09;	}

&#x09;	

&#x09;	return (node == \_tail) ? nullptr : node;

&#x09;}

&#x09;//					  \[node]

&#x09;// \[dummy]<->\[prevNode]<->\[posNode]<->\[3]<-> \[dummy]

&#x09;// \[head]					\[tail]

&#x09;void Insert(Node<T>\* posNode, int data)

&#x09;{

&#x09;	Node<T>\* node = new Node<T>(data);

&#x09;	Node<T>\* prevNode = posNode->prev;



&#x09;	prevNode->next = node;

&#x09;	node->prev = prevNode;

&#x09;	node->next = posNode;

&#x09;	posNode->prev = node;

&#x09;	\_size++;

&#x09;}



&#x09;void Remove(Node<T>\* node)

&#x09;{

&#x09;	if(node == nullptr || node == \_head || node == \_tail)

&#x09;		return;



&#x09;	Node<T>\* prevNode = node->prev;

&#x09;	Node<T>\* nextNode = node->next;



&#x09;	prevNode->next = nextNode;

&#x09;	nextNode->prev = prevNode;

&#x09;	

&#x09;	\_size--;

&#x09;	delete node;

&#x09;}



&#x09;void Print()

&#x09;{

&#x09;	Node<T>\* node = \_head->next;

&#x09;	while (node != \_tail)

&#x09;	{

&#x09;		cout << node->data << " ";

&#x09;		node = node->next;

&#x09;	}

&#x09;	cout << endl;

&#x09;}

&#x09;// \[delteNode] \[node]

&#x09;// \[dummy]<->\[1]<->\[2]<-> \[dummy]

&#x09;// \[head]					\[tail]

&#x09;

&#x09;//		\[node]

&#x09;//\[dummy]<->\[nextNode]<-><->\[2]<->\[3]<->\[dummy]

&#x09;//\[head]							\[tail]

&#x09;Node<T>\* AddHead(int data)

&#x09;{

&#x09;	Node<T>\* node = new Node<T>(data);



&#x09;	Node<T>\* nextNode = \_head->next;



&#x09;	node->next = nextNode;

&#x09;	nextNode->prev = node;

&#x09;	\_head->next = node;

&#x09;	node->prev = \_head;



&#x09;	return node;



&#x09;	/\* 더미추가전

&#x09;	if (\_head == nullptr)

&#x09;	{

&#x09;		\_head = node;

&#x09;		\_tail = node;

&#x09;	}

&#x09;	else

&#x09;	{

&#x09;		Node\* nextNode = \_head;

&#x09;		node->next = nextNode;

&#x09;		nextNode->prev = node;

&#x09;		\_head = node;

&#x09;	}\*/

&#x09;}

&#x09;//											\[node]

&#x09;//\[dummy]<->\[nextNode]<-><->\[2]<->\[prevNode]<->\[dummy]

&#x09;//\[head]									\[tail]

&#x09;Node<T>\* AddAtTail(int data)

&#x09;{

&#x09;	Node<T>\* node = new Node<T>(data);

&#x09;	Node<T>\* prevNode = \_tail->prev;



&#x09;	prevNode->next = node;

&#x09;	node->prev = prevNode;

&#x09;	node->next = \_tail;

&#x09;	\_tail->prev = node;



&#x09;	return node;

&#x09;}

private:

&#x09;Node<T>\* \_head = nullptr;

&#x09;Node<T>\* \_tail = nullptr;

&#x09;int \_size = 0;

};

