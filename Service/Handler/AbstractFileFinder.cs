using System;
using System.Collections;
using MyBackupCandidate;

namespace Service.Handler
{
    public abstract class AbstractFileFinder : IFileFinder
    {
        protected Config Config;
        protected string[] Files;
        private int _index = -1;

        public AbstractFileFinder(Config config)
        {
            Config = config ?? throw new ArgumentNullException(nameof(config));
        }

        // 將自己以 IEnumerator 型別回傳
        public IEnumerator GetEnumerator()
        {
            return this;
        }

        // 將 index 向前推進，並回傳是否超出範圍
        public bool MoveNext()
        {
            _index++;
            return _index < Files.Length;
        }

        // loop 順序 reset 回初始
        public void Reset()
        {
            _index = -1;
        }

        // 取得目前 index 的資料
        // foreach 到此 index 時建立 Candidate
        object IEnumerator.Current => CreateCandidate(Files[_index]);

        protected abstract Candidate CreateCandidate(string filename);
    }
}