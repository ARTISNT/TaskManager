using System.Diagnostics;
using AsyncAwait;

AsyncAwaitStuff asyncAwaitStuff = new AsyncAwaitStuff();

asyncAwaitStuff.RunSync();
await asyncAwaitStuff.RunAsync();

