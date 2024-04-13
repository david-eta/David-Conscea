# Introduction 
CSCE 590 Final Project - Spring 2024

In partnership with professors @ Capgemini, we built a Programming Certificate organizer.

Our project allows users to upload their certificates, track their status, and keep an eye on soon-to-expire certs.
It also allows system administrators to view all co-worker certificates, and confirm that their professionals are up to date.

# Team Members
- Ali Firooz
- Burt Sumner
- David Eta
- Nishwa Tuniki
- Patrick Burroughs
- Supriya Nayanala

# Getting Started
To get started:
- 1 Terminal:
 - cd into the frontend api folder: "consceafrontend"
 - `npm install`

# Build and Test
To Build the Project:

- 2 terminals
 - Terminal 1:
 - cd into the backend api folder: "Conscea-Api"
 - `dotnet run`

 - Terminal 2:
 - cd into the frontend api folder: "consceafrontend"
`npm start`

TODO: Describe how to run the tests. 


# DB Design

**Notes:**
- All attributes with no examples, have the same name in the excel files and thus will take the same values.
 
- If attribute `Certificate.Expire` is set to "True", the user should receive a notification when a certificate expires, that asks them to renew it (by updating the `CertArchive.ExpireDate`). Also if the `Certificate.Level == Advanced`, then `Certificate.Expire` should be set to True automatically.
If `Certificate.Expire` is False, then the certificate never expires.



[![Click me to edit](https://mermaid.ink/img/pako:eNqFk1FPwjAUhf_KTZ80gQT1yb0YIqIEVAL6YvZS18vWWFpz1y1O4L_bMgabwuzL0va7ueee9axYZASygCENJI-JL0MNbvWjyGTawqrc-iXdtr5GAqbjDgzHByS1JHV8QIaSUvvEl3gamfD_iLsllwpea22ihNPZRe-82k8To_EIsQfgnrhoaTEz6s_t2dXlrv41RdJOYqNDzuldak7FjpsnfCBjTO0BeTdGNQxLn7WS2nUqmU35uUWyI70wda9_C9wyld8QMowD6L91r3u9kJ2ueipFV_x3Rgj9EQwzLdyNtlylbeUTzFG1aOIWY0PF6YHvvj6laxkyL18uZOQqnHFKClgYggsokBMYrYqbSkfNkz5Ficyxbkv1Klue4N7NY84dMOGlQNNgpxDFwF9MW8hyKI81FDdjAxvT7a7XjTkCeOA5_vrnR7mQzVD5ti8mZKzDlkguA8KldOtFyGyCLjHMk4LThzdv4zieWTMvdMQCSxl2WPbpxe9yXR2ikNbQY5n6bfg3P97uGEk?type=png)](https://mermaid.live/edit#pako:eNqFk1FPwjAUhf_KTZ80gQT1yb0YIqIEVAL6YvZS18vWWFpz1y1O4L_bMgabwuzL0va7ueee9axYZASygCENJI-JL0MNbvWjyGTawqrc-iXdtr5GAqbjDgzHByS1JHV8QIaSUvvEl3gamfD_iLsllwpea22ihNPZRe-82k8To_EIsQfgnrhoaTEz6s_t2dXlrv41RdJOYqNDzuldak7FjpsnfCBjTO0BeTdGNQxLn7WS2nUqmU35uUWyI70wda9_C9wyld8QMowD6L91r3u9kJ2ueipFV_x3Rgj9EQwzLdyNtlylbeUTzFG1aOIWY0PF6YHvvj6laxkyL18uZOQqnHFKClgYggsokBMYrYqbSkfNkz5Ficyxbkv1Klue4N7NY84dMOGlQNNgpxDFwF9MW8hyKI81FDdjAxvT7a7XjTkCeOA5_vrnR7mQzVD5ti8mZKzDlkguA8KldOtFyGyCLjHMk4LThzdv4zieWTMvdMQCSxl2WPbpxe9yXR2ikNbQY5n6bfg3P97uGEk)
