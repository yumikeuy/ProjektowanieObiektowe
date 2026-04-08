using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Library.Entities
{
    public static class EndScreen
    {
        public static string EndText =>
           """
                                                              #####     #     #     # #######    ####### #     # ####### #####  
                                                             #     #   # #    ##   ## #          #     # #     # #       #    # 
                                                             #        #   #   # # # # #          #     # #     # #       #    # 
                                                             #  #### #     #  #  #  # #####      #     # #     # #####   #####  
                                                             #     # #######  #     # #          #     #  #   #  #       #   #  
                                                             #     # #     #  #     # #          #     #   # #   #       #    # 
                                                              #####  #     #  #     # #######    #######    #    ####### #     #
            """;

        public static string ReasonEndText(string reason)
        {
            return "\n\n\n\n\n\n\n" + EndText + "\n\n\n\n" + "                                                                      " +  reason + "\n\n\n\n\n";
        }
    }
}
