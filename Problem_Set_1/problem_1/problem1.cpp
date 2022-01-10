#include<bits/stdc++.h>

using namespace std;

int main(){
	freopen("egypt.txt", "r", stdin);
	
	int side_1,side_2,side_3;
	
	while(cin >> side_1 >> side_2 >> side_3){
		if(side_1 == 0 && side_2 == 0 && side_3 == 0)break;
		
		if( (side_1 * side_1) + (side_2 * side_2) == (side_3 * side_3)){
			cout << "right" << endl;
		}else{
			cout << "wrong" << endl;
		}
		
	}
	
	return 0;
}