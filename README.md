# HoneywellCaptuvoDemo

Connect to a Honeywell Captuvo Sled using Xamarin.iOS.  Make sure you have the following in your info.plist, otherwise the accessory will not work.

	<key>UISupportedExternalAccesoryProtocols</key>
	<array>
		<string>com.honeywell.scansled.protocol.decoder</string>
		<string>com.honeywell.scansled.protocol.msr</string>
		<string>com.honeywell.scansled.protocol.pm</string>
	</array>
	<key>UISupportedExternalAccessoryProtocols</key>
	<array>
		<string>com.honeywell.scansled.protocol.decoder</string>
		<string>com.honeywell.scansled.protocol.msr</string>
		<string>com.honeywell.scansled.protocol.pm</string>
	</array>
  
The Honeywell SDK used in this app is for the SL42.  You can find out how to bind the other sled SDKs here:  https://developer.xamarin.com/guides/ios/advanced_topics/binding_objective-c/walkthrough/
