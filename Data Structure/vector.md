### 동적배열(vector)

동적배열(vector)는 크기가 자동으로 증가/감소하는 배열이다.

베열과 달리 실행 중 크기 변경이 가능하다.

size -> 실제 데이터 개수

capacity -> 할당된 총 공간



### size vs capacity

| 구분       	| 설명            			|

| -----------	| -------------------------------	|

| size     	| 현재 저장된 데이터 개수 	|

| capacity 	| 할당된 메모리 크기    		|



예

size = 3 이고 capacity = 8 이면 앞으로 데이터를 5개 더 집어 넣을 수 있다.



### 중요한 특징

* 메모리는 연속적으로 할당된다.
* 인덱스로 접근이 가능하다 -> O(1)
* 크기가 자동으로 증가한다.(동적 확장)
* 삽입 시 재할당 발생 가능
* capacity는 자등으로 줄어들지 않는다.



### vecotr의 단점

재할당이 발생하면 모든 요소를 복사해야 하므로 비용이 크다.

또한 기존 iterator, 포인터, 참조가 모두 무효화된다.



### 시간 복잡도

| 연산              		| 시간      	|

| ------------------------	| -----------	|

| 접근              		| O(1)    	|

| push\_back       		| 평균 O(1) 	|

| push\_back (재할당) 	| O(n)    	|

| pop\_back        		| O(1)    	|

| 삽입/삭제 (중간)      	| O(n)    	|



Amortized O(1)

vector의 개념

push\_back은 평균적으로 O(1)이다.



이유

capacity가 부족할 때만 O(n)이다. 공간을 확장하고 새로이 복사하여 새로 할당하기 때문

그 이외에 capacity가 충분한 경우에는 O(1)

이걸 Amortized Complexity라고 한다.



### 코드



template <typename T>

class Vector

{

public:

&#x09;Vector() = default;

&#x09;\~Vector()

&#x09;{

&#x09;	if (\_buffer)

&#x09;		delete\[] \_buffer;

&#x09;}



&#x09;void clear()

&#x09;{

&#x09;	if (\_buffer)

&#x09;	{

&#x09;		delete\[] \_buffer;

&#x09;		\_buffer = new T\[\_cpapcity];

&#x09;	}



&#x09;	\_size = 0;

&#x09;}



&#x09;void push\_back(const T\& data)

&#x09;{

&#x09;	if (\_size == \_capacity)

&#x09;	{

&#x09;		int newCapacity = static\_cast<int>(\_capacity \* 1.5);



&#x09;		// 새로운 용량이 이전 용량이 같을 수도 있으니 1을 증가해준다

&#x09;		if (newCapacity == \_capacity)

&#x09;			newCapacity++;



&#x09;		reserve(newCapacity);

&#x09;	}



&#x09;	\_buffer\[\_size] = data;

&#x09;	\_size++;

&#x09;}



&#x09;void reserve(int capacity)

&#x09;{

&#x09;	if (\_capacity >= capacity)

&#x09;		return;



&#x09;	\_capacity = capacity;



&#x09;	T\* newData = new T\[\_capacity];



&#x09;	for (int i = 0; i < \_size; i++)

&#x09;	{

&#x09;		newData\[i] = \_buffer\[i];

&#x09;	}



&#x09;	if (\_buffer)

&#x09;		delete\[] \_buffer;



&#x09;	\_buffer = newData;

&#x09;}



&#x09;T\& back()

&#x09;{

&#x09;	return \_buffer\[\_size - 1];

&#x09;}



&#x09;void pop\_back()

&#x09;{

&#x09;	if (\_size == 0)

&#x09;		return;



&#x09;	\_size--;

&#x09;}



&#x09;void resize(int size)

&#x09;{

&#x09;	reserve(size);

&#x09;	\_size = size;

&#x09;}



&#x09;T\& operator\[](const int index)

&#x09;{

&#x09;	assert(index >= 0 \&\& index < \_size);

&#x09;	return \_buffer\[index];

&#x09;}



&#x09;int size() { return \_size; }

&#x09;int capacity() { return \_capacity; }

&#x09;bool empty() { return \_size == 0; }



public:

&#x09;int \_capacity = 0;

&#x09;int \_size = 0;

&#x09;T\* \_buffer = nullptr;

};



### vector 동작원리

기존 capacity = 4라고 가정을 해보자

거기서 새로이 push\_back을 하면 공간을 5개를 필요로 한다 그로인해

capacity = 8개로 증가를 해준다. 보통 1.5에서 2배를 해주고

기존 데이터를 복사를 한다.

이 과정으로 인해 재할당 시 기존 포인터/참조/iterator는 전부 무효화 된다.



### iterator invalidation

vector에서 push\_back을 해서 재할당이 발생시 기존의 주소는 다 바뀌게 된다.



예를 들어

int\* p = \&vec\[0];



vec.push\_back(10); // capacity 증가 발생



\*p → 위험 (쓰레기 값)



이런 코드가 있다고 하면 재할당으로 인해 바껴버린 주소를 접근하는

문제가 발생하여 메모리 오염이 발생할 수 있게 된다.

그래서 보통 이렇게 데이터를 저장해서 접근을 하는 경우

먼저 다 한 다음에 push\_back을 하거나 혹은 먼저 push\_back을 한 다음

변수로 저장하여 접근하는 편이 좋다.



### shrink\_to\_fit 개념

vector는 capacity를 줄이지는 않지만

vector.shrink\_to\_fit();을 호출하면 capacity를 size에 맞게 줄이도록 요청을 한다.

하지만 반드시 줄어든다는 보장은 없다.(비강제적 요청)



### 정리

vector는 동적 배열로, 내부적으로 연속된 메모리를 사용하며

size와 capacity를 분리하여 관리한다.

데이터가 capacity를 초과하면 더 큰 메모리를 할당하고 기존 데이터를 복사한다.

push\_back은 평균적으로 O(1)의 시간 복잡도를 가지지만,

재할당 시 O(n)이 발생할 수 있다.



vector는 내부적으로 동적 배열을 사용하며,

메모리 재할당 시 기존 데이터를 새로운 공간으로 복사하는 비용이 발생한다.

따라서 빈번한 재할당을 방지하기 위해 reserve를 사용하는 것이 중요하다.



