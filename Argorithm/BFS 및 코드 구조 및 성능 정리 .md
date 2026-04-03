### BFS 및 코드 구조



##### 1\. BFS를 사용하는 기준

* 다음 조건이 만족되면 BFS를 사용한다.
* 상태가 존대한다.(숫자, 좌표 등)
* 상태를 변화시키는 여러 연산이 있다.
* 최소 횟수 / 최단 거리를 구해야 한다



* BFS는 "가장 먼저 도착한 경로 = 최소 횟수"를 보장한다

##### 

##### 2\. BFS 기본 구조



queue<pair<int,int>> q; // (현재 값, 연산 횟수) 

vector<bool> visited(y + 1, false); q.push({x, 0});

    visited\[x] = true; 



while(!q.empty()) 

{ 

    auto \[cur, cnt] = q.front();

    q.pop();



    if(cur == y) 

        return cnt; 

    // 대충 여기서 연산을 하고 q에 push

    for(int next : {cur + n, cur \* 2, cur \* 3}) 	//예제로 프로그래머스에 있는 문제 푼 코드를 가져옴

    { 

    	// 이미 한번 방문 한 곳인지 확인

    	// 확인하는 이유 재수없을 경우 무한루프에 빠질 가능성이 생김

    	if(next <= y \&\& !visited\[next]) 

    	{ 

    		visited\[next] = true; 

    		q.push({next, cnt + 1}); 

    	} 

    }

}

##### 

##### 3\. visited 체크 위치

###### pop할 때 체크를 할 경우

* 큐에 중복 데이터가 들어감
* 그로인해 이미 방문 한곳임에도 한번 들어가서 체크를 하는 비효율이 발생



###### push에서 체크

* 큐에 중복된 데이터가 들어가는 것을 방지할 수 있다.
* 방문한 곳에 다시 들어가서 확인할 필요가 없고 큐에 데이터가 안들어가서 

    시간과 메모리를 절약할 수 있다.



결론

visited는 push할 때 체크한다.



##### 4 핵심 정리

* BFS = 최소 횟수 탐색
* visited = 중복 방지 장치
* push 시 visited 체크
* 범위 체크 필수
* 코드가 길어지면 구조 분리
* std::function은 편하지만 비용 존재

