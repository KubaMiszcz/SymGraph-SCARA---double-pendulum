function [e,ve,ae]=screw(t,a,b,xc,alfa)
%
% SCREW - wspó³rzêdne, prêdkoœci i przyspieszenia kartezjañskie w ruchu œrubowym;
%        
%	[e,ve,ae]=screw(t,a,b,xc,alfa)
%          [e,ve]=screw(t,a,b,xc,alfa)
%               e=screw(t,a,b,xc,alfa)
%
% gdzie t - wektor wartoœci parametru (kolumnowy), a - promieñ, b prêdkoœæ posuwu, xc - œrodek
% alfa - k¹t nachylenia osi wzglêdem p³aszczyzny xy (domyœlnie zero). 
%
% B.Ho³ota, 2012
%
 


if nargin < 5
   alfa=0;
end


x=xc(1)+a*cos(alfa)*cos(t)+b*sin(alfa)*t;
y=xc(2)+a*sin(t);
z=xc(3)-a*sin(alfa)*cos(t)+cos(alfa)*b*t;
 
e=[x y z];

if nargout>=2,
  vx=-a*cos(alfa)*sin(t)+sin(alfa)*b;
  vy=a*cos(t);
  vz=a*sin(alfa)*sin(t)+cos(alfa)*b;
  ve=[vx vy vz];
end

if nargout==3
  ax=cos(alfa)*(-a*cos(t));
  ay=-a*sin(t);
  az=sin(alfa)*a*cos(t);
  ae=[ax ay az];
end







