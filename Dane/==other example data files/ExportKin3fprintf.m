% exportuj danych .pos2 (wersja fprintf)
file='DaneKin3v2.kin3';
fid = fopen(file,'wt'); %usuwa poprzednia zawartosc
fprintf(fid, '##########################################\n');
fprintf(fid, '# dane do trybu Kin3                     #\n');
fprintf(fid, '##########################################\n');
fprintf(fid, '#dlugosc ramienia 1\n');
fprintf(fid,l1);
fprintf(fid, '#dlugosc ramienia 2\n');
fprintf(fid,l2);
fprintf(fid, '#th1\tth2\tth3\tomega1\tomega2\tomega3\n');
fprintf('%i wierszy wiec to chwile potrwa...\n',size(y,1));
for i=1:size(y,1)
  fprintf(fid, y(1,:));
end

fclose(fid);
%%% tutaj podsatw cos za th1
% dlmwrite(file,[y(:,1)*deg y(:,1)*deg y(:,2)*deg y(:,3) y(:,3) y(:,4)],'-append','delimiter','\t','precision','%.4f');
disp(['... plik ' file ' utworzony']);


