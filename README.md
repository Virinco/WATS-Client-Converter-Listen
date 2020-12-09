# WATS Client Converter - Listen

A WATS Client converter plugin for importing test data from Listen's SoundCheck test software to WATS.

## Getting Started

* [About WATS](https://wats.com/manufacturing-intelligence/)
* [About submitting data to WATS](https://virinco.zendesk.com/hc/en-us/articles/207424613)
* [About creating custom converters](https://virinco.zendesk.com/hc/en-us/articles/207424593)

## Download

You can download the latest released version of the converter [here](https://github.com/Virinco/WATS-Client-Converter-Listen/releases/latest). See the Custom Converter section in the [WATS Client Installation Guide](https://wats.com/download) for your version of the WATS Client for how to install a converter.

### Parameters

This converter uses the following parameters:

| Parameter         | Default value | Description                                                    |
|-------------------|---------------|----------------------------------------------------------------|
| partNumber        | ABC123        | If log is missing a part number, use this one.                 |
| partRevision      | 1.0           | If log is missing a revision, use this one.                    |
| sequenceName      | MainSequence  | If log is missing sequence name, use this one.                 |
| sequenceVersion   | 1.0.0         | If log is missing sequence version, use this one.              |
| operationTypeCode | 10            | If log is missing operation code (process code), use this one. |

## Testing

The project uses the [MSTest framework](https://docs.microsoft.com/en-us/visualstudio/test/quick-start-test-driven-development-with-test-explorer) for testing the converter.

It is setup with two tests; one for setting up the API by registering the client to your WATS, and one for running the converter.

The values are hardcoded in the test, so you will need to change the values to reflect your setup.
* In SetupClient, fill in your information in the the call to RegisterClient.
* In TestConverter, fill in the path to the file you want to test the converter with. There are example files in the Examples folder.
* Run SetupClient once, then you can run TestConverter as many times as you want.

## Contributing

We're open to suggestions! Feel free open an issue or create a pull request.

Please read [Contributing](CONTRIBUTING.md) for details on contributions.

## SoundCheck

### Step 1
The first step to using SoundCheck and WATS together is to add one or more **AutoSave to Text - Append** steps as in the sequence below.  These steps do the real work of saving SoundCheck data in a format that is recognized by the WATS SoundCheck converter.

![AutoSave Step](images/AutoSave%20Step.PNG)

### Step 2
Next, you will configure the **AutoSave to Text** step to store the desired data.  Note that each SoundCheck AutoSave step can only save one type of data (i.e., Data, Results, and Waveforms).  If you want to store both **Data** and **Results** you will need two **AutoSave to Text** steps as in the sequence above.  Note, the SoundCheck WATS converter does not support waveforms at this time.

Each **AutoSave to Text** step needs to be configured to save the **Time**, **Lot No.**, and **Serial No.** as shown below.  To store **Results** (e.g., single values), select the **Results** radio button above and choose the results that you want saved by selecting their names in the **Results** listbox.

![AutoSave Configure](images/AutoSave%20Results.PNG)

To save **Data** (e.g., curves) select the **Data** radio button and choose the data curves from the **Data** listbox as shown below:

![AutoSave Data](images/AutoSave%20Data.PNG)

### Step 3
At this point, you are ready to run the sequence and collect data.  Unless you change the default configuration, your data file will be stored in the ***$SoundCheckRoot*\data** folder where *$SoundCheckRoot* is the folder where SoundCheck is installed; in the above images, the file will be stored in **C:\SoundCheck 18\data**.

### Step 4
After running your sequence and saving data, you'll need to move the data file to the WATS SoundCheck converter input path folder as configured in the converter configuration.  In the configuration shown below, the WATS SoundCheck converter input path is ***C:\ProgramData\Virinco\WATS***:

![Converter Config](images/Converter%20Config.PNG)

## Contact

* Issues with the converter or suggestions for improvements can be submitted as an issue here on GitHub.
* Ask questions about WATS in the [WATS Community Help](https://virinco.zendesk.com/hc/en-us/community/topics/200229613)
* Suggestions for the WATS Client itself or WATS in general can be submitted to the [WATS Idea Exchange](https://virinco.zendesk.com/hc/en-us/community/topics/200229623)
* Sensitive installation issues or other sensitive questions can be sent to [support@virinco.com](mailto://support@virinco.com)
* Questions on using WATS with SoundCheck can be sent to [support@listeninc.com](mailto://support@listeninc.com)

## License

This project is licensed under the [LGPLv3](COPYING.LESSER) which is an extension of the [GPLv3](COPYING).