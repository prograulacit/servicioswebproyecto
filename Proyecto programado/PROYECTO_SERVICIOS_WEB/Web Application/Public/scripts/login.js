window.fbAsyncInit = function () {
    FB.init({
        appId: '3299543530092459',
        cookie: true,
        xfbml: true,
        version: 'v8.0'
    });

    FB.Event.subscribe('auth.authResponseChange', function (response) {
        if (response.status === 'connected') {
            FB.api(`/${response.authResponse.userID}/?fields=id,name,email,last_name`, function (response) {
                document.getElementsByClassName('social_name')[0].value = response.name;
                document.getElementsByClassName('social_email')[0].value = response.email;
                document.getElementsByClassName('social_username')[0].value = response.email;
                document.getElementsByClassName('submit_social_login')[0].click();
            });
        }
    });
};

function twitter_login() {
    OAuth.initialize('J3-XK6f6Bleub0KIYDA03fTxLnQ')
    OAuth.popup('twitter').done(function (result) {
        result.me().done(function (data) {
            document.getElementsByClassName('social_name')[0].value = data.name;
            document.getElementsByClassName('social_username')[0].value = data.alias;
            document.getElementsByClassName('submit_social_login')[0].click();
        })
    })
}
