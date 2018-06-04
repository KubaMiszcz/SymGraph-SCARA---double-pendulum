function [e,ve,ae]=screw(t,a,b,xc,alfa)
%
% SCREW - wsp�rz�dne, pr�dko�ci i przyspieszenia kartezja�skie w ruchu �rubowym;
%        
%	[e,ve,ae]=screw(t,a,b,xc,alfa)
%          [e,ve]=screw(t,a,b,xc,alfa)
%               e=screw(t,a,b,xc,alfa)
%
% gdzie t - wektor warto�ci parametru (kolumnowy), a - promie�, b pr�dko�� posuwu, xc - �rodek
% alfa - k�t nachylenia osi wzgl�dem p�aszczyzny xy (domy�lnie zero). 
%
% B.Ho�ota, 2012
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







