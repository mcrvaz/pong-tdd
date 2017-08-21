using System.Collections.Generic;

public interface IScoreViewManager {

	void Construct(List<ScoreView> currentScore);
	void UpdateScore(Dictionary<Players, int> newScore);

}
