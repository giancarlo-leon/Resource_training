#include<bits/stdc++.h>

using namespace std;

int getDif(int x, int y){
	return abs(x - y);
}

int main(){
	std::ifstream infile("jollyjumpers.txt");
	
	std::string line;
	while (std::getline(infile, line))
	{
    	std::istringstream iss(line);
    	int number, last_diff;
		bool isJolly = true;
		
		vector<int> sequence;
		sequence.reserve(3000);
		while(iss >> number){
			sequence.push_back(number);
		}
		
		if(sequence.size() == 1){
			cout << "Jolly" << endl;
		}else{
			last_diff = getDif(sequence[1] , sequence[0]);
			for(int i=2;i<sequence.size();i++){
				
				if(getDif(sequence[i] , sequence[i-1]) > last_diff){
					isJolly = false;
					break;
				}
				
				last_diff = getDif(sequence[i] , sequence[i-1]);
			}
			if(isJolly){
				cout << "Jolly" << endl;
			}else{
				cout << "Not jolly" << endl;
			}
		}
		
    	
		
	}
	
	
	
	return 0;
}