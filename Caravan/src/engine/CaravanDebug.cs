using System;
using System.Collections.Generic;

namespace CaravanEngine{
    public static class CaravanDebug{
        private static Stack<string> _stack; 

        public static float Timestamp {get; set;}


        public static string getTimestampAsString(){
            string outString = "";
            float cTimestamp = Timestamp;
            int minutes = (int)(cTimestamp / 60);
            cTimestamp -= minutes * 60;
            int seconds =  (int)cTimestamp;  
            cTimestamp -= seconds;  
            int milliseconds =(int)(cTimestamp * 1000); 

            string milliString = ""; 

            if(milliseconds >= 100){
                milliString = "" + milliseconds;
            }
            else if(milliseconds >= 10){
                milliString = "0" + milliseconds; 
            }
            else{
                milliString = "00" + milliseconds;
            }

            outString = $"{minutes}:{(seconds  >= 10 ? seconds : "0" + seconds)}.{milliString}";


            return outString; 
        }
        public static void LogMessage(string message){
            if(_stack == null){
                _stack = new Stack<string>();
            }

            string pushed = $"T = ({getTimestampAsString()})| {message}\n"; 
            _stack.Push(pushed); 
            Console.WriteLine(pushed); 
        }

        public static string PeekLogMessage(){
            return _stack.Peek(); 
        }

        public static string PopLogMessage(){
            return _stack.Pop(); 
        }


        //public static 

        
    }
}