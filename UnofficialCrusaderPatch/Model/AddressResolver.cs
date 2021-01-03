using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using static UCP.InstallHelper;

namespace UCP
{
    internal class AddressResolver
    {
        // Assign address to each label defined by an offset within current codeblock
        internal static void InitializeFixedLabelAddresses(List<Label> labels, byte[] data)
        {
            foreach (var label in labels)
            {
                string codeBlockName = label.CodeBlockName;
                AOB aob;
                try
                {
                    aob = AOB.AOBList[codeBlockName];
                }
                catch (KeyNotFoundException)
                {
                    aob = new AOB(codeBlockName);
                }
                aob.SetAddress(data);
                label.SetAddress(aob.Address.Value);
            }
        }

        // Define base addresses for InlineLabels and References
        internal static void ResolveBaseAddresses(IChange change, byte[] data, InstallData installData)
        {
            int startPosition;
            if (change is CodeReplacement)
            {
                CodeReplacement codeReplacement = change as CodeReplacement;

                // Get start address for the CodeReplacement
                AOB aob;
                try
                {
                    aob = AOB.AOBList[codeReplacement.CodeBlockName];
                } catch (KeyNotFoundException)
                {
                    aob = new AOB(codeReplacement.CodeBlockName);
                }
                 
                aob.SetAddress(data);
                startPosition = aob.Address.Value;
            }
            else if (change is CodeAllocation)
            {
                startPosition = installData.CodeAllocationCounter;
            }
            else if (change is MemoryAllocation)
            {
                startPosition = installData.MemoryAllocationCounter;
            }
            else
            {
                throw new Exception();
            }

            int currentPosition = startPosition;

            // Initialize labels declared inside change
            foreach (var element in change.GetByteValue())
            {
                if (!element.IsLabel && !element.IsReference && !element.IsSkip)
                {
                    if (element.value is byte)
                    {
                        currentPosition++;
                    }
                    else if (element.value is int)
                    {
                        currentPosition += 4;
                    }
                }
                else if (element.value is Label) // A label is a non-code marker so do not increment current position
                {
                    (element.value as Label).Address = currentPosition;
                }
                else if (element.value is Reference)
                {
                    (element.value as Reference).BaseAddress = currentPosition;
                    currentPosition += 4;
                }
                else if (element.value is SkipPosition)
                {
                    currentPosition += (element.value as SkipPosition).Count;
                }
            }

            if (change is CodeAllocation)
            {
                installData.CodeAllocationCounter += currentPosition - startPosition;
            }
            else if (change is MemoryAllocation)
            {
                installData.MemoryAllocationCounter += currentPosition - startPosition;
            }
        }

        internal static int GetTargetAddress(Reference reference, Dictionary<string, Label> labelDictionary, byte[] data, int allocatedCodeSectionVirtualStart, int allocatedMemorySectionVirtualStart)
        {
            string targetLabelName = reference.TargetLabelName;
            Label targetLabel = labelDictionary[targetLabelName];

            if (targetLabel is InlineLabel)
            {
                return targetLabel.Address;
            }
            else if (targetLabel is AllocatedCodeLabel)
            {
                return allocatedCodeSectionVirtualStart + targetLabel.Address;
            }
            else if (targetLabel is AllocatedMemoryLabel)
            {
                return allocatedMemorySectionVirtualStart + targetLabel.Address;
            }
            else
            {
                return GetFixedLabelTargetAddress(targetLabel, data);
            }
        }

        internal static int GetFixedLabelTargetAddress(Label targetLabel, byte[] data)
        {
            string codeBlockName = targetLabel.CodeBlockName;

            AOB aob;
            try
            {
                aob = AOB.AOBList[codeBlockName];
            }
            catch (KeyNotFoundException)
            {
                aob = new AOB(codeBlockName);
            }

            aob.SetAddress(data);
            targetLabel.SetAddress(aob.Address.Value);
            return targetLabel.Address;
        }
    }
}
