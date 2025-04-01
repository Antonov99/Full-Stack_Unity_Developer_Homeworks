using System.Collections.Generic;

public interface IGameRepository
{
    Dictionary<string, string> GetState();
    void SetState(Dictionary<string, string> gameState);
}