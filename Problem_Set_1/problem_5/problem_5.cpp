#include<bits/stdc++.h>

using namespace std;

bool canShrink(char image[][], int r, int zr){
	int currentRepeated = 0;
	
	for(int i=0;i<r;Repeated = 0
		for(int j=1;j<r;j++){
			if(image[i][j] == image[i][j-1]){
				currentRepeated++;
			}else{
				if(currentRepeated % zr != 0){
					return false;
				}
				currentRepeated = 0;
			}
		}
	}
	
	currentRepeated = 0;
	string last, current;
	
	last = string(image[0]);
	
	for(int i=1;i<r;i++){
		current = string(image[i]);
		
		if(last == current){
			currentRepeated++;
		}else{
			if(currentRepeated % zr != 0){
					return false;
			}
			currentRepeated = 0;
			last = string(image[i]);
		}
		
	}
	
	return true;
}

int main(){
	freopen("imagesize.txt", "r", stdin);
	
	int n,r,q;
	
	cin >> n;
	
	while(n--){
		cin >> r >> q;
		
		char image[r][r] = {' '};
		char pixel;
		int zoom_ratio;
		
		for(int i=0;i<r;i++){
			for(int j=0;j<r;j++){
				cin >> pixel;
				
				image[i][j] = pixel;
			}
		}
		
		if(r%q== 0 || q%r == 0){
			
			if(q>r){
				zoom_ratio = q/r;
				
				for(int i=0;i<r;i++){
					for(int l=1;l<=zoom_ratio;l++){
						for(int j=0;j<r;j++){
							for(int k=1;k<=zoom_ratio;k++){
								cout << image[i][j] << " ";
							}
						}
						cout << endl;
					}
				}
				
			}else{
				zoom_ratio = r/q;
				int column_counter = 0, row_counter = 0;
				
				
				if(canShrink(image,r, zoom_ratio)){
					char lastCharacter;
					string lastRow;
					
					
					for(int i=0;i<q;i++){
						for(int j=0;j<q;j++){
							lastCharacter = image[i][j];
						}
					}
					
				}else{
					cout << "Not Possible" << endl;
				}
				
			}
			
			
		}else{
			cout << "Not Possible" << endl;
		}
		
		
	}
	
	
	return 0;
}