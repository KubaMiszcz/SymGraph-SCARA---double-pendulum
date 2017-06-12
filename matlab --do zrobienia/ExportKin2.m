% exportuj danych .pos2
file='DaneKin2.kin2';
fid = fopen(file,'wt'); %usuwa poprzednia zawartosc
fprintf(fid, '##########################################\n');
fprintf(fid, '# dane do trybu Kin2                     #\n');
fprintf(fid, '##########################################\n');
fprintf(fid, '#dlugosc ramienia 1\n');
fprintf(fid,l1);
fprintf(fid, '#dlugosc ramienia 2\n');
fprintf(fid,l2);
fprintf(fid, '#th1\tth2\tomega1\tomega2\n');
fclose(fid);
fprintf('%i wierszy wiec to chwile potrwa...\n',size(y,1));
deg=180/pi;
dlmwrite(file,[y(:,1)*deg y(:,2)*deg y(:,3) y(:,4)],'-append','delimiter','\t','precision','%.4f');
disp(['... plik ' file ' utworzony']);


