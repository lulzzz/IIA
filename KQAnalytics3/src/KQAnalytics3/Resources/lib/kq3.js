'use strict';function mid(){function a(){return Math.floor(65536*(1+Math.random())).toString(16).substring(1)}return a()+a()+'-'+a()+'-'+a()+'-'+a()+'-'+a()+a()+a()}var kc=window._kqdaq||{},kqs=kc.s;'/'!==kqs.substr(-1)&&(kqs+='/');var ul=kc.u,tid=kc.tid,sid=window.localStorage.getItem('sid')||mid();window.localStorage.setItem('sid',sid);var rd='u='+ul+'&tid='+tid;String.prototype.format=function(){var a=arguments;return this.replace(/{(\d+)}/g,function(b,c){return'undefined'==typeof a[c]?b:a[c]})},function(){var a=new window.XMLHttpRequest;a.open('POST',kqs+'k',!0),a.setRequestHeader('Content-type','application/x-www-form-urlencoded'),a.onload=function(){// ok
// this.responseText
},a.send(rd)}();
