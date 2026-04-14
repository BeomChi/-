### 힙 (Heap)

힙(Heap)은 완전 이진 트리(Complete Binary Tree)를 기반으로,

부모 노드와 자식 노드 간의 대소 관계를 유지하는 자료구조이다.



힙 = 완전 이진 트리 + Heap Proerty

힙은 전체가 정렬된 구조가 아니라

부모와 자식 간의 관계만 유지되는 느슨한 정렬 구조이다.



따라서 :

루트 노드에는 항상 최댓값 또는 최솟값이 위치한다.

전체 데이터는 정렬되어 있지 않다.



### 힙의 종류

##### 최대 힙(max heap)

부모 노드의 값이 자식 노드의 값보다 크거나 같다.

Parent >= Child

\-> 루트 노드 = 최댓값



##### 최소 힙(min heap)

부모 노드의 값이 자식 노드의 값보다 작거나 같다.

Parent <= Child

\-> 루트 노드 = 최솟값



### 힙의 특징

부모 노드가 가진 값은 항상 자식 노드가 가진 값보다 크다.(최대 힙)

&#x20;1) 마지막 레벨을 제외한 모든 레벨에 노드가 꽉차 있다(완전 이진트리)

&#x20;2) 마지막 레벨에 노드가 있을 때는, 항상 왼쪽부터 순서대로 채워야 한다.

노드 개수를 알면, 트리 구조는 무조건 확정할 수 있다.

배열을 이용해 효율적으로 표현가능하다.



##### 베열 기반 표현

배열을 이용해서 힙 구조를 바로 표현할 수 있다.

&#x20;1) i 번 노드의 왼쪽 자식은 \[(2 \* i) + 1]번

&#x20;2) i 번 노드의 오른쪽 자식은 \[(2 \* i) + 2]번

&#x20;3) i 번 노드의 부모는 \[(i - 1) / 2]번



### 연산

##### 삽입(push) -> Heapify Up

마지막 위치에 데이터 추가

부모와 비교하면서 위로 이동

O(logN)



##### 삭제(pop) -> Heapify Down

루트 제거

마지막 노드를 루트로 이동

자식과 비교하며 아래로 이동

O(logN)



##### 최상단 값 조회

O(1)



### 시간 복잡도

|연산|시간복잡도|
|-|-|
|삽입(push)|O(log N)|
|삭제(pop)|O(log N)|
|최상단 조회(top)|O(1)|



힙의 높이 = log N

\-> 이동 연산은 트리 높이에 비례한다.



#### C++에서의 힙

##### make\_heap

vector<int> v = {10, 20, 30};

make\_heap(v.begin(), v.end());

vector를 힙 구조로 변환

모든 요소 접근 가능



##### priority\_queue

priority\_queue<int> pq;

내부적으로 힙 사용

top()만 접근 가능







### 코드

힙을 사용해서 구현한 우선순위 큐

template<typename T,typename Predicate = less<T>>

class PriorityQueue

{

public:

&#x20;   //O(logN) 트리의 높이 의존적이다

&#x20;   void push(const T\& data)

&#x20;   {

&#x20;       // 우선 힙 구조부터 맞추는 작업

&#x20;       \_heap.push\_back(data);



&#x20;       // 도장깨기 시작

&#x20;       int current = static\_cast<int>(\_heap.size()) - 1;



&#x20;       // 루트 노드까지

&#x20;       while (current > 0)

&#x20;       {

&#x20;           // 부모 노드와 비교해서 더 작으면 패배

&#x20;           int next = (current - 1) / 2;

&#x20;           /\*if (\_heap\[now] < \_heap\[next])

&#x20;               break;\*/

&#x20;           if (\_predicate(\_heap\[current], \_heap\[next]))

&#x20;               break;



&#x20;           // 데이터 교체

&#x20;           ::swap(\_heap\[current], \_heap\[next]);

&#x20;           current = next;

&#x20;       }

&#x20;   }



&#x20;   //O(logN)

&#x20;   void pop()

&#x20;   {

&#x20;       \_heap\[0] = \_heap.back();

&#x20;       \_heap.pop\_back();



&#x20;       int current = 0;



&#x20;       while (true)

&#x20;       {

&#x20;           int left = 2 \* current + 1;

&#x20;           int right = 2 \* current + 2;

&#x20;           

&#x20;           if (left >= (int)\_heap.size())

&#x20;               break;



&#x20;           int next = current;



&#x20;           //왼쪽 비교

&#x20;           if (\_heap\[next] < \_heap\[left])

&#x20;               next = left;



&#x20;           // 둘 중 승자를 오른쪽과 비교

&#x20;           //if (right < \_heap.size() \&\& \_heap\[next] < \_heap\[right])

&#x20;           if (right < \_heap.size() \&\& \_predicate(\_heap\[next] , \_heap\[right]))

&#x20;               next = right;



&#x20;           //왼족 || 오른쪽 둘 다 현재 값보다 작으면 종료

&#x20;           if (next == current)

&#x20;               break;



&#x20;           ::swap(\_heap\[current], \_heap\[next]);



&#x20;           current = next;

&#x20;       }

&#x20;   }



&#x20;   //O(1)

&#x20;   T\& top()

&#x20;   {

&#x20;       return \_heap\[0];

&#x20;   }



&#x20;   //O(1)

&#x20;   bool empty()

&#x20;   {

&#x20;       return \_heap.empty();

&#x20;   }

private:

&#x20;   vector<T> \_heap;

&#x20;   Predicate \_predicate;

};



int main()

{

&#x20;   PriorityQueue<int, greater<int> > pq;



&#x20;   pq.push(10);

&#x20;   pq.push(40);

&#x20;   pq.push(30);

&#x20;   pq.push(50);

&#x20;   pq.push(20);



&#x20;   int value = pq.top();

&#x20;   pq.pop();

&#x20;   

}



### iterator invalidation

힙은 내부적으로 vector를 사용하기 때문에

재할당이 발생하면 기존 주소가 무효화된다.



int\* p = \&vec\[0];

vec.push\_back(10);

\*p-> 위험



해결 방안 push\_back 이후에 주소를 가져온다.



### 사용처

우선순위 큐

다익스트라 알고리즘

작업 스케줄링

k번째 큰 값/ 작은 값 찾기



### 정리

힙(Heap)은 완전 이진 트리 구조를 기반으로,

부모-자식 간의 대소 관계를 유지하는 자료구조이다.



삽입과 삭제는 O(logN),

최댓값/최솟값 조회는 O(1)로 매우 빠르다.



전체 정렬이 아닌 부분 정렬 구조이며,

우선순위 큐 구현에 사용된다.



