namespace Microsoft.Etw.BombGame
{

    [ManifestEvent("{8400115e-3a7a-4fb0-95ca-6121397f7c4a}", 0, 0)]
    public class TracedEvent : SystemEvent
    {
        [EventField("win:UnicodeString")]
        public string Message { get; set; }
    }
}
