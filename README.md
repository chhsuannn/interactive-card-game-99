1. 解壓縮後打開，在第一個資料夾頁面，就是只有一個"interactive-card-game-99-main" (點進去會看到一堆檔案)，在那個頁面的空白處 Shift + 右鍵 ➔ 選擇 在此開啟 PowerShell 視窗
   輸入並執行指令：Get-ChildItem -Recurse | Unblock-File，不會有任何回饋，那就對了。
2. .sln檔無法執行的話，回到資料夾中，找到這個99.1.sln，右鍵選「內容」，一般裡面的「安全性」，解除封鎖。
