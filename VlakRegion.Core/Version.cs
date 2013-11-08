using System;
using VlakRegion.Core.RecordArchive;

namespace VlakRegion.Core
{
    public struct Version
    {
        public Int16 Major;
        public Int16 Minor;
        public Int16 Build;
        public Int16 Revision;

        public static Version Parse(String version)
        {
            String[] subStrings = version.Split('.');

            if (subStrings.Length != 4)
            {
                throw new FormatException();
            }

            Version versionResult = new Version();

            versionResult.Major = Int16.Parse(subStrings[0]);
            versionResult.Minor = Int16.Parse(subStrings[1]);
            versionResult.Build = Int16.Parse(subStrings[2]);
            versionResult.Revision = Int16.Parse(subStrings[3]);

            return versionResult;
        }

        public Version(short major, short minor, short build, short revision)
        {
            Major = major;
            Minor = minor;
            Build = build;
            Revision = revision;
        }

        public void Save(IRecordArchiveWriter writer)
        {
            writer.NewRecord(new RecordDescriptor(Record.Version, 1));

            writer.Write(Major);
            writer.Write(Minor);
            writer.Write(Build);
            writer.Write(Revision);

            writer.EndRecord();
        }

        public void Load(IRecordArchiveReader reader)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return String.Format("{0}.{1}.{2}.{3}", Major, Minor, Build, Revision);
        }
    }
}
