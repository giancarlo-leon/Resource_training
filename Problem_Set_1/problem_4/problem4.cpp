#include<bits/stdc++.h>

using namespace std;



int CountRelationships(map<string, vector<string>> graph, map<string, bool> friends, string u){
	stack<string> bfs;
	int c = 0;
	bfs.push(u);
	friends[u] = true;
	while(!bfs.empty()){
		for(string v: graph[bfs.top()]){
			if(!friends[v]){
				bfs.push(v);
				friends[v] = true;
			}
			
		}
		c++;
		bfs.pop();
	}
	
	return c;
}

int main(){
	freopen("virtualfriends.txt", "r", stdin);
	
	int t,f;
	string u,v;
	cin >> t;
	
	while(t--){
		map<string, vector<string>> graph;
		map<string, bool> friends;
		
		cin >> f;
		
		while(f--){
			cin >> u >> v;
			graph[u].push_back(v);
			graph[v].push_back(u);
			friends[u] = false;
			friends[v] = false;
			
			cout << CountRelationships(graph, friends, u) << endl;
			
		}
		
		
	}
	
	return 0;
}