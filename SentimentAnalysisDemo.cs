using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using IBM.Watson.DeveloperCloud.Services.NaturalLanguageUnderstanding.v1;
using IBM.Watson.DeveloperCloud.Logging;
using IBM.Watson.DeveloperCloud.Utilities;
using IBM.Watson.DeveloperCloud.Connection;

public class SentimentAnalysisDemo : MonoBehaviour {

	// Use this for initialization
	public Text ResponseField;
	private NaturalLanguageUnderstanding _nlu;
	//private string _analysisModel = "en-es";
	private bool _getModelsTested = false;
	private bool _analyzeTested = false;

	void Start () 
	{
		LogSystem.InstallDefaultReactors ();	

		Credentials naturalLanguageUnderstandingCredentials = new Credentials () {
			Username = "b2e711a5-5d95-4988-a355-8653923d7769",
			Password = "1VRamFU1cXr1",
			Url = "https://gateway.watsonplatform.net/natural-language-understanding/api"
		};
		_nlu = new NaturalLanguageUnderstanding (naturalLanguageUnderstandingCredentials);
		analyse("In the rugged Colorado Desert of California, there lies buried a treasure ship sailed there hundreds of years ago by either Viking or Spanish explorers. Some say this is legend; others insist it is fact. A few have even claimed to have seen the ship, its wooden remains poking through the sand like the skeleton of a prehistoric beast. Among those who say they’ve come close to the ship is small-town librarian Myrtle Botts. In 1933, she was hiking with her husband in the Anza-Borrego Desert, not far from the border with Mexico. It was early March, so the desert would have been in bloom, its washed-out yellows and grays beaten back by the riotous invasion of wildflowers. Those wildflowers were what brought the Bottses to the desert, and they ended up near a tiny settlement called Agua Caliente. Surrounding place names reflected the strangeness and severity of the land: Moonlight Canyon, Hellhole Canyon, Indian Gorge. Try Newsweek for only $1.25 per week To enter the desert is to succumb to the unknowable. One morning, a prospector appeared in the couple’s camp with news far more astonishing than a new species of desert flora: He’d found a ship lodged in the rocky face of Canebrake Canyon. The vessel was made of wood, and there was a serpentine figure carved into its prow. There were also impressions on its flanks where shields had been attached—all the hallmarks of a Viking craft. Recounting the episode later, Botts said she and her husband saw the ship but couldn’t reach it, so they vowed to return the following day, better prepared for a rugged hike. That wasn’t to be, because, several hours later, there was a 6.4 magnitude earthquake in the waters off Huntington Beach, in Southern California. Botts claimed it dislodged rocks that buried her Viking ship, which she never saw again.There are reasons to doubt her story, yet it is only one of many about sightings of the desert ship. By the time Myrtle and her husband had set out to explore, amid the blooming poppies and evening primrose, the story of the lost desert ship was already about 60 years old. By the time I heard it, while working on a story about desert conservation, it had been nearly a century and a half since explorer Albert S. Evans had published the first account. Traveling to San Bernardino, Evans came into a valley that was “the grim and silent ghost of a dead sea,” presumably Lake Cahuilla. “The moon threw a track of shimmering light,” he wrote, directly upon “the wreck of a gallant ship, which may have gone down there centuries ago.” The route Evans took came nowhere near Canebrake Canyon, and the ship Evans claimed to see was Spanish, not Norse. Others have also seen this vessel, but much farther south, in Baja California, Mexico. Like all great legends, the desert ship is immune to its contradictions: It is fake news for the romantic soul, offering passage into some ancient American dreamtime when blood and gold were the main currencies of civic life.The legend does seem, prima facie, bonkers: a craft loaded with untold riches, sailed by early-European explorers into a vast lake that once stretched over much of inland Southern California, then run aground, abandoned by its crew and covered over by centuries of sand and rock and creosote bush as that lake dried out…and now it lies a few feet below the surface, in sight of the chicken-wire fence at the back of the Desert Dunes motel, $58 a night and HBO in most rooms.Totally insane, right? Let us slink back to our cubicles and never speak of the desert ship again. Let us only believe that which is shared with us on Facebook. Let us banish forever all traces of wonder from our lives. Yet there are believers who insist that, using recent advances in archaeology, the ship can be found. They point, for example, to a wooden sloop from the 1770s unearthed during excavations at the World Trade Center site in lower Manhattan, or the more than 40 ships, dating back perhaps 800 years, discovered in the Black Sea earlier this year.");
	}
	public void analyse(string text)
	{
		Parameters parameters = new Parameters()
		{
			text = "Analyze various features of text content at scale. Provide text, raw HTML, or a public URL, and IBM Watson Natural Language Understanding will give you results for the features you request. The service cleans HTML content before analysis by default, so the results can ignore most advertisements and other unwanted content.",
			return_analyzed_text = true,
			language = "en",
			features = new Features()
			{
				entities = new EntitiesOptions()
				{
					limit = 50,
					sentiment = true,
					emotion = true,
				},
				keywords = new KeywordsOptions()
				{
					limit = 50,
					sentiment = true,
					emotion = true
				}
			}
		};

		_nlu.Analyze (OnAnalyseResponse, OnFail, parameters);
	}
	private void OnAnalyseResponse(AnalysisResults response, Dictionary<string,object> customData)
	{
		Log.Debug("ExampleNaturalLanguageUnderstanding.OnAnalyze()", "AnalysisResults: {0}", customData["json"].ToString());
		_analyzeTested = true; 
	}
	private void OnFail(RESTConnector.Error error, Dictionary<string,object> customData)
	{
		Log.Debug ("SentimentAnalysisDemo.OnFail()", "Error (0)", error.ToString ());
	}


}
