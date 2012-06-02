/* gojo.js */


MyGojo = Ember.Application.create();

MyGojo.SiteInfo = Ember.Object.extend({
    id: null,
    title: null,
    url: null,
    priority: 1,
    isVisible: true,
    isEditable: true,
    
    SiteInfoChanged: function () {
        // do something
    }
});

MyGojo.SiteInfoController = Ember.ArrayProxy.create({
    content: [],
    
    pushObject: function (item, ignoreStorage) {
        if (!ignoreStorage)
            MyGojo.SiteInfoStore.create(item);
        return this._super(item);
    },
    
    removeObject: function (item) {
        MyGojo.SiteInfoStore.remote(item);
        return this._super(item);
    }
});


MyGojo.SiteInfoStore = (function () {
    
    // generate 4 random hex digits
    var S4 = function() {
        return (((1 + Math.random()) * 0x10000) | 0).toString(16).substring(1);
    };

    // generate a pseudo-Guid by concatenating the random hex
    var guid = function() {
        return (S4() + S4() + "-" + S4() + "-" + S4() + "-" + S4() + "-" + S4() + S4() + S4());
    };

    // the SiteInfosStore is represented by a single JavaScript object in *localStorage*. Created with meaningful name.
    // for older browsers? use amplify.js -- See: http://amplifyjs.com/api/store/
    var Store = function(name) {
        this.name = name;
        var store = localStorage.getItem(this.name);
        this.data = (store && JSON.parse(store)) || { };

        // save current state of the Store to localStorage
        this.save = function() {
            localStorage.setItem(this.name, JSON.stringify(this.data));
        };

        // CRUD Methods
        // Add with Guid if it doesn't already have an id
        this.create = function(model) {
            if (!model.get('id')) model.set('id', guid());
            return this.update(model);
        };

        // Update a model by replacing its copy in `this.data`.
        this.update = function(model) {
            this.data[model.get('id')] = model.getProperties('id', 'title', 'url', 'position');
            this.save();
            return model;
        };

        // Retrieve a model from `this.data` by id.
        this.find = function(model) {
            return MyGojo.SiteInfo.create(this.data[model.get('id')]);
        };

        // Return the array of all models currently in storage.
        this.findAll = function() {
            var result = [];
            
            for (var key in this.data) {
                var SiteInfo = MyGojo.SiteInfo.create(this.data[key]);
                result.push(SiteInfo);
            }

            return result;
        };
        
        // Delete a model from `this.data`, returning it.
        this.remove = function (model) {
            delete this.data[model.get('id')];
            this.save();
            return model;
        };

    };
    
    return new Store('SiteInfo-emberjs');

})();






