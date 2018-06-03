function targetmatrix=wierszNaKolumny(sourcematrix,newcolumnnumber)
% przerabia nam jeden dlugi wiersz na macierz kolumnowa o n kolumnach
% liczba wierszy pierwotnej macierzy musi byc podizelna przez n
% 
% macierzwynikowa=wierszNaKolumny(macierzjednowierszowa,liczbakolumn)
% 
% Jakub Be³ch 2016
oldrowelements=size(sourcematrix,2);
if mod(oldrowelements,newcolumnnumber)==0
    newrow=[];
    targetmatrix=[];
    actelement=1;
    
    for j=1:newcolumnnumber:oldrowelements
        for i=actelement:(actelement+newcolumnnumber-1)
            newrow=[newrow oldmatrix(i)]  ;
        end
        targetmatrix=[targetmatrix; newrow];
        newrow=[];
        actelement=actelement+newcolumnnumber;
    end
    
else fprintf('liczba wierszy macierzy rowna %i nie jest podzielna przez liczbe kolumn %i',oldrowelements,newcolumnnumber)
end
    


   

