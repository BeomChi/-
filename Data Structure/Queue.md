# 큐 (Queue)

### 큐(Queue)

큐(Queue)는 먼저 들어온것이 먼저 나가는 형태이며 이걸 FIFO(FIRST IN FIRST OUT)라고 한다.

스택 (Stack)과는 다른 방식이다.



Enqueue는 큐(Queue)에 데이터를 입력하는 동작이고,

DeQueue는 큐(Queue)에 데잍를 출력하는 동작이다.





대충 뒤에다가 데이터를 집어넣고 앞에서 데이터를 꺼내는 방식

예시

A -> B -> C -> D 순으로 들어오면

A -> B -> C -> D 순으로 나간다



예

* 줄 서기
* 대기열
* 프린터 작업 큐
* 컨베이어 벨트



### 큐 특징

큐의 특징

* 뒤에서 데이터 삽입
* 앞에서 데이터 삭제
* 중간 데이터 접근 불가능
* 먼저 들어온 데이터가 먼저나감
* 입구(front)와 출구(back)가 따로 존재



### 큐 기본 연산

| 연산		         | 설명          		|

| -------------- 	 | ----------- 		|

| push / enqueue | 데이터 삽입 (뒤)  	|

| pop / dequeue  | 데이터 삭제 (앞)  	|

| front          	| 맨 앞 데이터 확인  	|

| back           	| 맨 뒤 데이터 확인 	|

| empty          	| 큐가 비어있는지 확인 |

| size           	| 큐 크기        		|



C++ STL 에서는

* queue.push()
* queue.pop()
* queue.front()
* queue.back()
* queue.empty()
* queue.size()



### 시간 복잡도

| 연산    	| 시간 복잡도 	|

| ----- 	| ------ 		|

| push  	| O(1)   		|

| pop   	| O(1)   		|

| front 	| O(1)   		|

| back  	| O(1)   		|



### 큐 구현 방법

1. 큐 구현 방법은 크게 3가지가 있다.
2. 배열 기반 큐
3. 원형 큐
4. 연결 리스트 기반 큐
5. STL queue 사용



### 원형 큐(Circular Queue)

일반 배열로 큐를 만들면 문제가 생긴다.



앞쪽 공간이 비어도 뒤에 더 이상 못 넣는 문제가 발생한다.

그래서 배열월 원형처럼 사용한다.

* \_back = (\_back + 1) % capacity;
* \_front = (\_front + 1) % capacity;



이렇게 해서 배열을 원형으로 사용한다.





### 구현 예제

template<typename T>

class Queue

{

public:

&#x20;   	Queue()

&#x20;   	{

&#x20;      		\_container.resize(100);

&#x20;   	}



&#x09;void push(const T\& value)

&#x09;{

&#x20;   		if (\_size == \_container.size())

&#x20;   		{

&#x20;       		Vector<T> newContainer;

&#x20;       		newContainer.resize(\_container.size() \* 2);



&#x20;       		for (int i = 0; i < \_size; i++)

&#x20;       		{

&#x20;           			newContainer\[i] = \_container\[(\_front + i) % \_container.size()];

&#x20;       		}



&#x20;       		\_container = newContainer;

&#x20;       		\_front = 0;

&#x20;       		\_back = \_size;

&#x20;   		}



&#x20;   		\_container\[\_back] = value;

&#x20;   		\_back++;



&#x20;   		// 원형 유지

&#x20;   		if (\_back == \_container.size())

&#x20;       		\_back = 0;



&#x20;   		\_size++;

&#x09;}



&#x20;   	void pop()

&#x20;   	{

&#x20;       	if (\_size == 0)

&#x20;           		return;



&#x20;       	\_front = (\_front + 1) % \_container.size();

&#x20;       	\_size--;

&#x20;   	}



&#x20;   	T\& front()

&#x20;   	{

&#x20;       	return \_container\[\_front];

&#x20;   	}



&#x20;   	bool empty()

&#x20;   	{

&#x20;       	return \_size == 0;

&#x20;   	}



&#x20;   	int size()

&#x20;   	{

&#x20;       	return \_size;

&#x20;   	}



private:

&#x20;   	vector<T> \_container;

&#x20;   	int \_front = 0;

&#x20;   	int \_back = 0;

&#x20;   	int \_size = 0;

};



### 큐가 사용되는 곳

1. BFS(너비 우선 탐색)
2. 작업 스케줄링
3. 프린터 작업 대기열
4. 네트워크 패킷처리
5. 게임 서버 이벤트 처리
6. 버퍼
7. 레벨 순회(트리 Level Order)



Queue -> BFS

Stack -> DFS



스택 vs 큐 비교

| 구조 	| Stack 	| Queue 	|

| -- 		| ----- 	| ----- 	|

| 방식 	| LIFO  	| FIFO  	|

| 삽입 	| top   	| back  	|

| 삭제 	| top   	| front 	|

| 사용 	| DFS   	| BFS   	|



정리

Queue = FIFO (First Int First Out)

뒤에서 넣고 (front), 앞에서 뺀다(pop)

BFS, 작업 스케줄링, 버퍼에서 사용



