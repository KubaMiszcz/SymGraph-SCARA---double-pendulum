% exportuj danych .pos2
file='DaneTsk2.tsk2';
fid = fopen(file,'wt'); %usuwa poprzednia zawartosc
fprintf(fid, '##########################################\n');
fprintf(fid, '# dane do trybu Tsk2                     #\n');
fprintf(fid, '##########################################\n');
fprintf(fid, '#dlugosc ramienia 1\n');
fprintf(fid,l1);
fprintf(fid, '#dlugosc ramienia 2\n');
fprintf(fid,l2);
fprintf(fid, '#t\tth1\tth2\tstan_narzedzia\n');
fclose(fid);
fprintf('%i wierszy wiec to chwile potrwa...\n',size(y,1));
deg=180/pi;
dlmwrite(file,[t y(:,1)*deg y(:,2)*deg],'-append','delimiter','\t','precision','%.4f');
disp(['... plik ' file ' utworzony']);


