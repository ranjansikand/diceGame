// Manager base class
// Overridden by game state managers


using System.Collections;

public abstract class Manager {
    protected GameManager gm;
    public bool complete = false;

    public Manager(GameManager gm) { this.gm = gm; }
    protected abstract IEnumerator Routine();
}
