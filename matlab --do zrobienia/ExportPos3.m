% exportuj danych .pos2
file='DanePos3.pos3';
fid = fopen(file,'wt'); %usuwa poprzednia zawartosc
fprintf(fid, '##########################################\n');
fprintf(fid, '# dane do trybu Pos3                     #\n');
fprintf(fid, '##########################################\n');
fprintf(fid, '#dlugosc ramienia 1\n');
fprintf(fid,l1);
fprintf(fid, '#dlugosc ramienia 2\n');
fprintf(fid,l2);
fprintf(fid, '#th1\tth2\tth3\n');
fclose(fid);
fprintf('%i wierszy wiec to chwile potrwa...\n',size(y,1));
deg=180/pi;
%%% tutaj podsatw cos za th1
dlmwrite(file,[y(:,1) y(:,1) y(:,2) ]*deg,'-append','delimiter','\t','precision','%.4f');
disp(['... plik ' file ' utworzony']);


