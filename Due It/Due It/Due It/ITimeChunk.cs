using System;
using System.Collections.Generic;
using System.Text;

namespace Due_It
{
    internal interface ITimeChunk
    {
        TimeSlot ChunkStart(); // Start of the Chunk being scheduled using TimeSlot
        TimeSlot ChunkEnd();   // End of the Chunk being scheduled using TimeSlot
        int ChunkCount();      // 
        CompletionTime ChunkRemaining();
        string NoteIntake();

    }
}
