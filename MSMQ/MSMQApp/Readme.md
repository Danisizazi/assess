	Assumptions: 
		-The user can run the application on Visual Studio, preferrably 2022	
		-MSMQ has been enabled in the server.
		-The user is able to check the if there are messages in the queue, from the 'Services and Applications - Message Queueing' window.
		-MSMQ.Messaging has been package has been installed in VS2022
		-Async and synchronous concepts are not part of the assessment.
		-Unit tests are not required for the assessment, as we only creating a basic queue where the producer generates random numbers and add them to the queue, while the consumer should read and print these numbers.
			Unit tests are covered in the multiple threads assessment.
		-Message priority is not part of the assessment.
		-Required generated numbers are random, but necessarily unique
