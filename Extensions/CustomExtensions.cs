using LogGenerator.Business.Constants;
using LogGenerator.Business.Enums;

namespace LogGenerator.Extensions
{
	public static class CustomExtensions
	{
		// Gets Field Delimiter
		public static FieldDelimiter ToFieldDelimiter (this string delimiterText)
		{
			return
				delimiterText switch
				{
					Delimiters.TAB => FieldDelimiter.Tab,
					Delimiters.DOUBLE_HASH_EXCLAMATION => FieldDelimiter.DoubleHashExclamation,
					Delimiters.DOUBLE_TILDE_EXCLAMATION => FieldDelimiter.DoubleTildeExclamation,
					_ => throw new ArgumentException ($"Delimiter text \"{delimiterText}\" is not a valid one.")
				};
		}

		// Gets text of Field Delimiter
		public static string ToText (this FieldDelimiter fieldDelimiter)
		{
			return
				fieldDelimiter switch
				{
					FieldDelimiter.Tab => "\t",
					FieldDelimiter.DoubleHashExclamation => Delimiters.DOUBLE_HASH_EXCLAMATION,
					FieldDelimiter.DoubleTildeExclamation => Delimiters.DOUBLE_TILDE_EXCLAMATION
				};
		}

		// Gets Unique ID type
		public static LogUniqueIds ToLogUniqueId (this string logUniqueIdText)
		{
			return
				logUniqueIdText switch
				{
					UniqueIDs.GUID => LogUniqueIds.Guid,
					UniqueIDs.RUNNING_NUMBER => LogUniqueIds.RunningNumber,
					UniqueIDs.RUNNING_HEX_NUMBER => LogUniqueIds.RunningHexNumber,
					_ => throw new ArgumentException ($"Unique ID type text \"{logUniqueIdText}\" is not a valid one.")
				};
		}

		// Gets a dictionary of what fields are selected
		public static IDictionary<string, bool> GetCheckedItemsDictionary (this CheckedListBox checkedListBox)
		{
			// LINQ query to get Dictionary<string, bool> of checked items
			var checkedItems = checkedListBox.CheckedItems.Cast<string> ();
			var checkedItemsDictionary = checkedItems.ToDictionary (item => item, item => true);

			// Include unchecked items with false value
			checkedItemsDictionary
				= checkedItemsDictionary
					.Union (
						checkedListBox.Items.Cast<string> ()
							.Except (checkedItems).ToDictionary (item => item, item => false)
					)
					.ToDictionary (kvp => kvp.Key, kvp => kvp.Value);

			// Log entry type is not displayed, but will be printed on to the log generated.
			checkedItemsDictionary [LogFields.LOG_ENTRY_TYPE] = true;

			return checkedItemsDictionary;
		}

		public static int GetFileSizeInMbFromText (this string sizeText)
		{
			var sizeIsInGb = sizeText.Contains ("GB");
			var size = Convert.ToInt16 (sizeText.Replace ("MB", string.Empty).Replace ("GB", string.Empty).Trim ());

			if (sizeIsInGb)
			{
				size *= 1024;
			}

			return size;
		}
	}
}