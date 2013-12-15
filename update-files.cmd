SET src=d:\projects\NuGet\src
SET dst=d:\projects\Utils\MonoNetPortableClientLibraryUtil\src

copy %src%\Core\Extensions\CollectionExtensions.cs %dst%
copy %src%\..\Common\CommonResources.cs %dst%
copy %src%\..\Common\CommonResources.Designer.cs %dst%
copy %src%\..\Common\CommonResources.resx %dst%
copy %src%\Core\Packages\Constants.cs %dst%
copy %src%\Core\Utility\EnvironmentUtility.cs %dst%
copy %src%\Core\Utility\FrameworkNameEqualityComparer.cs %dst%
copy %src%\Core\Logging\IFileConflictResolver.cs %dst%
copy %src%\Core\ProjectSystem\IFileSystem.cs %dst%
copy %src%\Core\Packages\IFrameworkTargetable.cs %dst%
copy %src%\Core\Loggin\ILogger.cs %dst%
copy %src%\Core\Utility\IVersionSpec.cs %dst%
copy %src%\Core\Logging\MessageLevel.cs %dst%
copy %src%\Core\NETPortable\MonoNetPortableProfilePathResolver.cs %dst%
copy %src%\Core\NETPortable\NetPortableProfile.cs %dst%
copy %src%\Core\NETPortable\NetPortableProfileCollection.cs %dst%
copy %src%\Core\NETPortable\NetPortableProfileTable.cs %dst%
copy %src%\Core\Resources\NuGetResources.Designer.cs %dst%
copy %src%\Core\Resources\NuGetResources.resx %dst%
copy %src%\Core\Utility\ReadOnlyHashSet.cs %dst%
copy %src%\Core\SemanticVersionTypeConverter.cs %dst%
copy %src%\Core\SemanticVersion.cs %dst%
copy %src%\Core\Utility\VersionSpec.cs %dst%
copy %src%\Core\Utility\VersionUtility.cs %dst%
copy %src%\Core\Extensions\XElementExtensions.cs %dst%
copy %src%\Core\Utility\XmlUtility.cs %dst%
copy %src%\Core\Logging\FileConflictResolution.cs %dst%
copy %src%\Core\Extensions\EnumerableExtensions.cs %dst%
copy %src%\Core\ProjectSystem\PhysicalFileSystem.cs %dst%
copy %src%\Core\Utility\HashCodeCombiner.cs %dst%
copy %src%\Core\Utility\PathUtility.cs %dst%
copy %src%\Core\Logging\NullLogger.cs %dst%
copy %src%\Core\Utility\UriUtility.cs %dst%
copy %src%\Core\Utility\PathValidator.cs %dst%