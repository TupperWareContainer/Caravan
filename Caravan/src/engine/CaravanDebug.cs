using System;
using System.Collections.Generic;
using CaravanEngine.UI; 
using Microsoft.Xna.Framework;
namespace CaravanEngine{
    public static class CaravanDebug{
        private static Stack<string> _stack; 

        public static float Timestamp {get; set;}

        public static bool DisplayMessages {get; set;}

        public static int  MaxDisplayMessages {get; set;}

        // private static Canvas _debugCanvas; 
        // private static UIText _debugOutput; 

        // public static void Init(){

        //     _debugCanvas = new Canvas("Debug Canvas", 10); 
        //     _debugOutput = new UIText(new Transform(new Vector2(0f,0f),new Vector2(1f, 1f),0f),_debugCanvas,1); 
        // }


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

        public static void LogMessage(string message, bool printStackTrace){
            if(_stack == null){
                _stack = new Stack<string>();
            }

            string pushed = $"T = ({getTimestampAsString()})| {message}";
            string ending = Environment.StackTrace;

            if(printStackTrace) pushed += "\n" + ending + "\n";
            else pushed += "\n";
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