#include<bits/stdc++.h>

using namespace std;

int main(){
	freopen("minesweeper.txt", "r", stdin);
	
	int n;
	char pos;
	
	cin >> n;
	int map[n][n] = {0};
	
	for(int i=0;i<n;i++){
		for (int j=0;j<n;j++){
			cin >> pos;
			if(pos == '.'){
				map[i][j] = 0;
			}else{
				map[i][j] = 1;
			}
		}
	}
	
	
	for(int i=0;i<n;i++){
		for (int j=0;j<n;j++){
			cin >> pos;
			
			if(pos == 'x'){
				cout << 
					((i > 0 ? map[i-1][j] : 0) + 
					 (i < n-1 ? map[i+1][j] : 0) + 
					 (j > 0 ? map[i][j-1] : 0) + 
					 (j < n-1 ? map[i][j+1] : 0) + 
					 (i > 0 ? (j > 0 ? map[i-1][j-1] : 0) : 0) + 
					 (i > 0 ? (j < n-1 ? map[i-1][j+1] : 0) : 0) + 
					 (i < n-1 ? (j > 0 ? map[i+1][j-1] : 0) : 0) + 
					 (i < n-1 ? (j < n-1 ? map[i+1][j+1] : 0) : 0)
					);
			}else{
				cout << '.';
			}
			
		}
		cout << endl;
	}
	
	
	
	
	
	return 0;
}