using System;
using System.Text.RegularExpressions;

namespace Methapone
{
    class Program
    {
        static string text = "";

        static void Main(string[] args)
        {
            Console.WriteLine("Hi User!");
            do
            {
                Console.WriteLine("Write a word:");
                text = Console.ReadLine();
                CreateMetaphoneWithoutVowel();
                CreateMetaphoneWithVowel();
                Console.WriteLine("------");
            }
            while (text != "1");
        }

        private static void CreateMetaphoneWithVowel()
        {
          //change starting vowel to capital
            char[] characters = text.ToCharArray();
        
            if(text.StartsWith("a")){
                characters[0] = 'A';
                text = new string(characters);           
            }
            if (text.StartsWith("e"))
            {
                characters[0] = 'E';
                text = new string(characters);
            }
            if (text.StartsWith("i"))
            {
                characters[0] = 'I';
                text = new string(characters);
            }
            if (text.StartsWith("o"))
            {
                characters[0] = 'O';
                text = new string(characters);
            }
            if (text.StartsWith("u"))
            {
                characters[0] = 'U';
                text = new string(characters);
            }

            //if text does not start with vowel->delete vowel from the text
            if (text.Contains("a"))  text = text.Replace("a", "");
            if (text.Contains("e")) text = text.Replace("e", "");
            if (text.Contains("i"))  text = text.Replace("i", "");
            if (text.Contains("o")) text = text.Replace("o", "");
            if (text.Contains("u")) text = text.Replace("u", "");              

            Console.WriteLine(text.ToUpper());
        }


            private static void CreateMetaphoneWithoutVowel() 
            {
            char[] characters = text.ToCharArray();


            //if text starts with kn, gn, pn, ac, or wr -> drop first letter
            if (text.StartsWith("kn") || text.StartsWith("gn") || text.StartsWith("pn") || text.StartsWith("ac") || text.StartsWith("wr") ) {
                text = text.Remove(0,1);              
            }


            //if text starts with x -> change x to s
            if (text.StartsWith("x"))
            {
                characters[0] = 's';
                text = string.Join("", characters);             
            }


            //if text starts with wh -> change wh to w
            if (text.StartsWith("wh"))
            {
                text = text.Remove(1, 1);             
            }


            //if text ends with mb -> delete b 
            if (text.Contains("b") && text.EndsWith("mb"))  text = text.Remove(text.Length - 1, 1);
            else if (text.Contains("b")) text = text.Replace("b", "B");


            //if text contains c then change it 
            if (text.Contains("c")) {
                if (text.Contains("cia") || text.Contains("ch")) 
                { 
                    text = text.Replace("c", "X"); 
                }
                if (  (text.Contains("ci") && !text.Contains("cia")) || text.Contains("ce") || text.Contains("cy") )
                {
                    text = text.Replace("c", "S");
                }

                if (text.Contains("sch") )
                {
                    text = text.Replace("c", "K");
                }
                if (text.Contains("ck"))
                {
                    text = text.Replace("ck", "k");
                }
                else 
                { 
                    text = text.Replace("c", "K"); 
                }
            }


            //if text contains d then change it
            if (text.Contains("d"))
            {
                if (text.Contains("dge") || text.Contains("dgy") || text.Contains("dgi"))
                {
                    text = text.Replace("d", "J");
                }
                else
                {
                    text = text.Replace("d", "T");
                }
            }


            //if text contains f then change it
            if (text.Contains("f")) text = text.Replace("f", "F");


            //if text contains g then change it
            if (text.Contains("g"))
            {
                if (text.Contains("gh") && !text.EndsWith("g") && !text.Contains("ga") && !text.Contains("ge") && !text.Contains("gi") && !text.Contains("go") && !text.Contains("gu"))
                {
                    text = text.Replace("g", "");
                }
                if (text.Contains("gn") || text.Contains("gned"))
                {
                    text = text.Replace("g", "");
                }
                if (!text.Contains("gg")  && ( text.Contains("ge") || text.Contains("gi") || text.Contains("gy")))
                {
                    text = text.Replace("g", "J");
                }
                else
                {
                    text = text.Replace("g", "K");
                }
            }


            //if text contains h and before h there is a vowel then delete it.  
            if (text.Contains("h"))
            {
                if ( (   text.Contains("ah") || text.Contains("eh") || text.Contains("ih") || text.Contains("oh") || text.Contains("uh") )
                 && (  !text.Contains("ha") && !text.Contains("he")&&  !text.Contains("hi") && !text.Contains("ho") && !text.Contains("hu")       )  )    
                    
                        text = text.Replace("h", "");     
                else text = text.Replace("h", "H");
            }


            //if text contains j then change it
            if (text.Contains("j")) text = text.Replace("j", "J");


            //if text contains k and k is after c then delete it
            if (text.Contains("k")) {
                if (text.Contains("ck") || text.Contains("cK") || text.Contains("CK") || text.Contains("Ck")) 
                    text = Regex.Replace(text, "ck", "", RegexOptions.IgnoreCase);

                else text = text.Replace("k", "K");
            }


            //if text contains l then change it
            if (text.Contains("l")) text = text.Replace("l", "L");


            //if text contains m then change it
            if (text.Contains("m")) text = text.Replace("m", "M");


            //if text contains n then change it
            if (text.Contains("n")) text = text.Replace("n", "N");


            //if text contains p and h is after p then change it to F
            if (text.Contains("p")){
                if (text.Contains("ph") || text.Contains("pH") || text.Contains("PH")) text = Regex.Replace(text, "ph", "F", RegexOptions.IgnoreCase);
                
                else text = text.Replace("p", "P");
            }


            //if text contains q then change it to K
            if (text.Contains("q")) text = text.Replace("q", "K");


            //if text contains r then change it to R
            if (text.Contains("r")) text = text.Replace("r", "R");


            //if text contains s then change it 
            if (text.Contains("s"))
            {
                if(text.Contains("sh") || text.Contains("sH") || text.Contains("SH")) 
                    text = Regex.Replace(text, "sh", "Xh", RegexOptions.IgnoreCase);           
            }


            //if text contains t then change it 
            if (text.Contains("t"))
            {
                if (text.Contains("tia") || text.Contains("tio")) { 
                    text = Regex.Replace(text, "tia", "Xia", RegexOptions.IgnoreCase);
                    text = Regex.Replace(text, "tio", "Xio", RegexOptions.IgnoreCase);
                }

                else if (text.Contains("tch")) text = text.Replace("tch", "ch");
                else if (text.Contains("th")) text = text.Replace("th", "O");
                else text = text.Replace("t", "T");
            }


            //if text contains v then change it to F
            if (text.Contains("v")) text = text.Replace("v", "F");


            //if text contains w then change it
            if (text.Contains("w"))
            {
                if (text.Contains("w") && !text.Contains("wa") && !text.Contains("we") && !text.Contains("wi") && !text.Contains("wo") && !text.Contains("wu"))
                {
                    text = text.Replace("w", "");
                }       
                else
                {
                    text = text.Replace("w", "W");
                }
            }


            //if text contains x then change it to KS
            if (text.Contains("x")) text = text.Replace("x", "KS");


            //if text contains y then change it
            if (text.Contains("y"))
            {
                if (text.Contains("y") && !text.Contains("ya") && !text.Contains("ye") && !text.Contains("yi") && !text.Contains("yo") && !text.Contains("yu"))
                {
                    text = text.Replace("y", "");
                }
                else
                {
                    text = text.Replace("y", "Y");
                }
            }


            //if text contains z then change it to S
            if (text.Contains("z")) text = text.Replace("z", "S");
        }         
        }
    }


       
                
                
                
                
                
                
            
            
            
            
            
            
  

