/* app.js */

/*
    See:    http://stackoverflow.com/questions/9171583/easy-way-to-precompile-emberjs-handlebar-templates-with-nodejs
            http://stackoverflow.com/questions/10274391/is-it-possible-to-load-handlebar-template-with-script-tag-or-define-handlebar-t
            http://handlebarsjs.com/precompilation.html
            https://github.com/interline/ember-skeleton
            https://github.com/envone/ember-runner
            http://jsfiddle.net/pangratz666/wxrxT/
            http://jsfiddle.net/pangratz666/58tFP/

            http://www.eishay.com/2012/03/fetching-emberjs-handlebars-templates.html
            http://www.infoq.com/articles/emberjs
            http://www.adobe.com/devnet/html5/articles/flame-on-a-beginners-guide-to-emberjs.html
            https://gist.github.com/1622236
            https://github.com/emberjs/ember-rails
 */

// Create Ember application namespace
var App = Em.Application.create();



/******  Routing ******/
App.Router = Em.Router.extend({

    root: Em.State.extend({
        index: Em.State.extend({
            route: '/',
            redirectsTo: 'sitelinks'
        }),

        sitelinks: Em.State.extend({
            route: '/sitelinks',
            showSiteLink: Em.State.transitionTo('sitelink'),
            connectOutlets: function(router) {

                /* this 'connectOutlet' call does:
                * creates new instance of 'App.SiteLinksView' using the
                'sitelinks.handlebars' template
                * sets the 'content' prop. of 'sitelinksController' to a list
                of all sitelinks available (App.SiteLinks.find())
                * makes 'sitelinksController' the controller for the new 'App.SiteLinksView'
                * connects the new view to the outlet in 'application.handlebars'

                Note:  Always provide the content for a view's controller when you create a view!
                */
                router.get('applicationController')
                      .connectOutlet(App.SiteLinksView, App.SiteLink.find());
            }
        }),

        sitelink: Em.State.extend({
            route: '/sitelinks/:sitelink_id',
            connectOutlets: function(router, sitelink) {
                router.get('applicationController')
                      .connectOutlet(App.SiteLinkView, sitelink);
            }
        })
    })
});
