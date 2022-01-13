#include<bits/stdc++.h>

using namespace std;


int graph[100000][100000] = {0};

int calculateDistance(vector<int> stores)
{


    int min_path = INT_MAX;
    do {
 

        int current_pathweight = 0;
 

        int k = 0;
        for (int i = 0; i < stores.size(); i++) {
            current_pathweight += graph[k][stores[i]];
            k = stores[i];
        }
        current_pathweight += graph[k][0];
 

        min_path = min(min_path, current_pathweight);
 
    } while (
        next_permutation(stores.begin(), stores.end()));
 
    return min_path;
}

int main(){
	freopen("shopping.txt", "r", stdin);
	
	int t,n,m,s, i,j,d;
	vector<int> stores;
	
	cin >> t;
	
	while(t--){
		cin >> n >> m;
		
		while(m--){
			cin >> i >> j >> d;
			graph[i][j] = d;
			
			
			
		}
		
		cin >> s;
		
		while(s--){
			cin >> i;
			stores.push_back(i);
		}
		
		cout << calculateDistance(stores) << endl;
		
	}
	
	
	
	return 0;
}