using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace 
{
    public class SaveSystem
    {
        public void Save(Board board){
            string map;
            for (int i = 0; i < 5 ;i++){
                for (int j = 0; i < 5; i++){
                    map+= Board.map[i,j]
                    map+= "-";
                }
            } 

        }

        public void Load(Board board){
            string map = ReadAllText(SaveFile.txt);
            for (int i = 0; i < 5 ;i++){
                for (int j = 0; i < 5; i++){
                    
                }
            } 

        }
    }
}