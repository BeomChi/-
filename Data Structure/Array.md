### 배열(Array)

배열(Array)은 동일한 타입의 데이터들이 연속된 메모리 공간에 저장되는 자료구조이다.

각 요소는 인덱스를 통해 접근할 수 있으며,인덱스는 0부터 시작한다.



##### 가장 큰 특징은 

연속된 메모리 공간

Random Access 가능

arr\[i\[ = \*(arr + i)

배열은 내부적으로

주소 + index \* 자료형 크기



예

int arr\[5];

arr\[3] = base address + 3 \* sizeof(int)

그래서 O(1) 이다.



즉, arr\[3] -> 바로 접근 가능 -> O(1)



### 배열의 특징

메모리가 연속적이다.

인덱스로 바로 접근 가능

크기가 고정되어 있다.

중간 삽입/삭제가 느리다.

캐시 효율이 좋다.



### 왜 삽입 삭제가 느린가?

\[1]\[2]\[3]\[4]

여기서 2 앞에 10 삽입

\[1]\[10]\[2]\[3]\[4]

뒤에 있는 것들을 전부  한 칸씩 밀어야 함

O(n)



### 시간 복잡도

| 연산         	| 시간 복잡도 	|

| ---------- 		| ------ 		|

| 접근 (index) 	| 	O(1) 		|

| 탐색         	| 	O(n) 		|

| 맨 뒤 삽입     	| 	O(1)   	|

| 중간 삽입      	| 	O(n) 		|

| 삭제         	| 	O(n) 		|



### Array vs Linked List

| 구분  	| Array 	| Linked List 	|

| --- 		| ----- 	| -----------	 	|

| 메모리 	| 연속    	| 비연속      	|

| 접근  	| O(1)  	| O(n)        	|

| 삽입  	| O(n)  	| O(1)        		|

| 삭제  	| O(n)  	| O(1)        		|

| 캐시  	| 좋음    	| 나쁨          	|



### C++ 에서 배열 종류

int arr\[10];	// 일반 배열

array<int,10>;	// STL array

vector<int>;	// 동적배열



##### 차이

| 타입		| 저장 위치		| 크기 결정 시점	| 특징						|

| int arr\[N]	| 스택(Stack)	| 컴파일 타임	| 가장 빠르나 크기 제한이 있음	|

| std::array	| 스택(Stack)	| 컴파일 타임	| 일반 배열을 객체화 (안정성↑)	|

| std::vector	| 힙(Heap)		| 런타임		| 동적 할당 사용 (유연함↑)		|







template <typename T>

class Array

{

public:

&#x09;explicit Array(int capactiy = 100) : \_capacity(capacity)

&#x09;{ 

&#x09;	\_buffer = new T\[capacity];

&#x09;}



&#x09;\~Array()

&#x09;{

&#x09;	delete\[] \_buffer;

&#x09;}



&#x09;void push\_back(const T\& data)

&#x09;{

&#x09;	if (\_size == \_capacity)

&#x09;		return;



&#x09;	\_buffer\[\_size] = data;

&#x09;	\_size++;

&#x09;}



&#x09;T\& operator\[](int index)

&#x09;{

&#x09;	assert(index >= 0 \&\& index < \_size);



&#x09;	return \_buffer\[index];

&#x09;}



&#x09;int size() { return \_size; }

&#x09;int capacity() { return \_capacity; }



public:

&#x09;int \_capacity = 0;

&#x09;int \_size = 0;

&#x09;T\* \_buffer = nullptr;



};



### 마지막 정리

배열 (Array)은 동일한 타입의 데이터를 연속된 메모리 공간에 저장하며,

인덱스를 통해O(1) 시간에 임의 접근(Random Access)이 가능한 자료구조이다.

하지만 중간 삽입과 삭제는 데이터 이동이 필요하므로 O(n)의 시간이 소요된다.

