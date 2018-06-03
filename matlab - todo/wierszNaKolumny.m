function newmatrix=wierszNaKolumny(oldmatrix,newcolumnnumber)
% przerabia nam jeden dlugi wiersz na macierz kolumnowa o n kolumnach
% liczba wierszy pierwotnej macierzy musi byc podizelna przez n
% Jakub Be³ch 2016
oldrowelements=size(oldmatrix,2);
if mod(oldrowelements,newcolumnnumber)==0
    newrow=[];
    newmatrix=[];
    newrownumber=oldrowelements/newcolumnnumber;
    actelement=1;
    
    for j=1:newcolumnnumber:oldrowelements
        for i=actelement:(actelement+newcolumnnumber-1)
            newrow=[newrow oldmatrix(i)]  ;
        end
        newmatrix=[newmatrix; newrow];
        newrow=[];
        actelement=actelement+newcolumnnumber;
    end
    
else fprintf('liczba wierszy macierzy rowna %i nie jest podzielna przez liczbe kolumn %i',oldrowelements,newcolumnnumber)
end
    


   

