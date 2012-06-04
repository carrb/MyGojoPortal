/* gojo.js */

(function() {
    var gojo = window.gojo = function() {
        
        // Properties
        

        // Initialization
        init = function() {
            console.info("*gojo* initializing...");
            console.info("*gojo*: object instantiated and initialized!");
        },
        

        // Methods
        logStatus = function() {
            console.info("showStatus called.");
        };
        


        return {
            init: init,
            logStatus: logStatus
        };
        
    }; // end of inner function
    
    // could have other code here
    
})();  // immediately invoke


