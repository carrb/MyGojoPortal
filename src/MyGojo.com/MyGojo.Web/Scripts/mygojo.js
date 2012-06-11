/* gojo.js 

   Reveaing Module Pattern

*/

(function() {
    var MyGojoApp = window.MyGojoApp = function() {
        
        // Properties
        

        // Initialization
        init = function() {
            console.info("MyGojoApp: object instantiated and initialized!");
        },
        

        // Methods
        logStatus = function() {
            console.info("logStatus called.");
        };
  
        return {
            init: init,
            logStatus: logStatus
        };
        
    }; // end of inner function
    
    // could have other code here
    
})();  // immediately invoke


