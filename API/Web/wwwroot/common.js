"use strict";(self.webpackChunktesting_system=self.webpackChunktesting_system||[]).push([[592],{7461:(v,l,n)=>{n.d(l,{e:()=>h});var _=n(5861),s=n(1180),i=n(6125),u=n(2223),c=n(8567);let h=(()=>{class o{get userToken(){return this.tokenInfo}constructor(e){(0,s.Z)(this,"apiService",void 0),(0,s.Z)(this,"tokenInfo",void 0),this.apiService=e}auth(e){var t=this;return(0,_.Z)(function*(){try{return t.tokenInfo=yield t.apiService.post("/api/Token/set",null,{headers:{Authorization:"Bearer "+e}}),null==t.tokenInfo?{error:{message:"Access token was null!"}}:(i.O.storage.set(t.tokenInfo),{token:t.tokenInfo})}catch(r){return console.log(r),{error:r}}})()}login(e,t){var r=this;return(0,_.Z)(function*(){try{return r.tokenInfo=yield r.apiService.post("/api/Auth/login",{userName:e,password:t}),null==r.tokenInfo?{error:{message:"Access token was null!"}}:(i.O.storage.set(r.tokenInfo),{token:r.tokenInfo})}catch(a){return console.log(a),{error:a}}})()}logout(){var e=this;return(0,_.Z)(function*(){try{return yield e.apiService.post("/api/Auth/logout",null),i.O.storage.remove(),!0}catch(t){console.log(t)}return!1})()}}return(0,s.Z)(o,"\u0275fac",function(e){return new(e||o)(u.LFG(c.s))}),(0,s.Z)(o,"\u0275prov",u.Yz7({token:o,factory:o.\u0275fac})),o})()}}]);