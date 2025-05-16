using System;

namespace CyberSecurityChatBot
{
    public static class AsciiArt 
    {
        public static void Display() 
        {
            string[] artLines = @"
        :@%                                               #@=                   
                       @ #@@@@@@@%@#            *@#            #@%@@@@@@@# @                   
                                        @      @@@-     :@@@      @                                
                                         #@@@      %@@@%      @@@#                                 
                       @@            @@-      @@@         @@@      :@@            @@               
                      @.-@@%@        @  #@@%                   %@@#  #        @%@@= @              
                            %        @ #                           % @        @                    
                            @        @ #          %@@@@@%          % %        @                    
                            #@@@@@@@%@ #         @       @         % @@@@@@@@@%                    
                                     @ *:        #       #         % @                             
                                     @ :#      @%%%@@@@@%%%@      :# @                             
                        @%@              @  @      #           +      %  @              %%@            
                        @ @#*########### @  @      #    @ @    #      @  @ ###########**@ @            
                                     #  @      #    @ @    #      @  #                             
                                      @  *     *    *-*    +     :: @                              
                                      @  @     @%%%#####%%%@     @  @                              
                                @      @  @                     @  @      @                        
                       %@@      @       @  #@                 @%  @       @      @@%               
                       @ @%#%%%#=        @%  @@             @@  #@        :#%%%#%@ @               
                                           @=  *@         @#  :@                                   
                                             %@   *@@ @@#   @@                                     
                                            @:  @@       @@   @                                    
                               @ #@%@@@@%%@@       @@@@@       %@%@@@@@%@# @                       
                               #@@                                       %@%
            ".Split('\n');

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            foreach (string line in artLines)
            {
                Typewriter.WriteLine(line, 5);
            }
            Console.ResetColor();
        }
    }
}