<%@ Page Language="C#" AutoEventWireup="true"  %>

<%
//**********************************************************************
// Module/File:	SessionWatch.asp
//
// Application:	any
//
// Author:		Dave Bruley, Darrin Broin
//
// Created:		February 2006
//
// Purpose:		Server-side file that writes out client-side 
//              Include like this:
//
//				Server.Execute("~/SessionWatch.aspx")
//
//				If the user leaves the browser showing the page 
//				this script is on for a long time (1 minute less than the
//				Session.Timeout), this script will automatically navigate
//				the browser to the "killSession.asp" page. 
//
//				If the session timesout while the user is in a modal dialog,
//				then if the functions within this file were implemented correctly,
//				the modal dialog will close, returning a constant value that
//				indicates the window closed due to timeout and the parent
//				window will evaluate that value to determine if it should
//				redirect to the "killSession" page. 
//
//				"killSession.aspx" should do two things:
//				(1) session.abandon() 'to make sure the session is dead
//				(2) show the user an explanation of what happened.
//				
// Assumptions:	No other variables or functions within the client file
//				share the same name as those in this file.
//
// Dependencies:	"killSession.aspx" must be in the current working directory
//				relative to the file this is included into.
//
// Notes:		This file should be included in all ASP files in your 
//				application that the user interacts with.  Thus, if your
//				application has frames, include this file only in pages
//				that the user frequently interacts with.
//
//				This works for all pages.  If remote scripting is used,
//				Call the SessionWatch_ResetTimer function to reset the 
//				countdown where appropriate.
//
//				If no Remote Scripting is used, this page will work too.
//				No additional code interaction is needed.
//
//				There's also a function to determine if a modal dialog
//				returned a value indicating the session expired.  This
//				function will navigate to the KillSession page if the 
//				dialog timed out.		
//
//				Some of the code and comments adapted from other modules
//				created by Darrin Broin. 
//
//**********************************************************************
%>
<script language="JavaScript" type="text/javascript">
<!--

/********************* Begin Session Timeout Routines **************************/
var mblnIsModalDialog = false;					//true if working in a modaldialog
var mSessionTimer;								//ID returned from SetTimeout function
var mSESSION_TIMEOUT = <%=(Session.Timeout - 1) %>; 	
    //Server's session timeout value
var mstrKillSessionURL = '<%=Response.ApplyAppPathModifier("~/KillSession.aspx")%>'; 
//page to navigate to when session expires
var mstrDIALOG_RETURN_KILLSESSION = "KILLSESSION"; //Value returned from a dialog when it timesout

//Initiate the timeout countdown
SessionWatch_StartTimer();
	
/*****************************************************************************
* Purpose: Cancels the default timer, sets value that modaldialog is in use
*		   and resets the timer for use in a modaldialog window.
*
* Note: Call from window_onLoad event of modal dialog page
*****************************************************************************/
function SessionWatch_InitializeModalDialogTimer()
{
	mblnIsModalDialog = true;
	SessionWatch_ResetTimer();
}	

/*****************************************************************************
* Purpose: Starts a Timeout countdown to expire the app session right before
*          the server session expires
*****************************************************************************/
function SessionWatch_StartTimer()
{
	mSessionTimer = window.setTimeout(SessionWatch_KillSession, mSESSION_TIMEOUT * (60 * 1000));
}

/*****************************************************************************
* Purpose: Start a timeout for modal dialog windows.
*****************************************************************************/ 
function SessionWatch_StartDialogTimer()
{
	mSessionTimer = window.setTimeout(SessionWatch_KillDialog, mSESSION_TIMEOUT * (60 * 1000));
}
 
/*****************************************************************************
* Purpose: Reset the Timeout countdown.  Usually used in pages that do
*			remote scripting as the page never refreshes.
*****************************************************************************/ 
function SessionWatch_ResetTimer()
{
	SessionWatch_ClearTimer();
	if (mblnIsModalDialog)
	{
		SessionWatch_StartDialogTimer();
	}
	else
	{
		SessionWatch_StartTimer();
	}
} 

/*****************************************************************************
* Purpose: clear the Timeout countdown.  Usually used in pages that do
*		   remote scripting as the page never refreshes.
*****************************************************************************/ 
function SessionWatch_ClearTimer()
{
	window.clearTimeout(mSessionTimer);
}

/*****************************************************************************
* Purpose: Navigates to a URL once the session has expired
*****************************************************************************/
function SessionWatch_KillSession()
{		
	window.top.location = mstrKillSessionURL;   
}  

/*****************************************************************************
* Purpose: When session times out while in a modaldialog, return value
*			indicating session is dead and close window
*****************************************************************************/ 
function SessionWatch_KillDialog()
{
	////window.returnValue = mstrDIALOG_RETURN_KILLSESSION;
	////window.close();
    window.opener.dialogWin.returnedValue = mstrDIALOG_RETURN_KILLSESSION;
    window.opener.SessionWatch_CheckDialogTimeOut(mstrDIALOG_RETURN_KILLSESSION);
    Close();
}

/*****************************************************************************
* Purpose: Determine if a dialog window returned a value indicating the 
*			Session expired.  If it did, naviagate to the URL for session timeouts.
* Input: vstrReturnValue - The return value from the dialog window
* Returns: Boolean - True if dialog timed out.  Calling procedure should check
*				return value to know to exit processing.
*				Example:
*					if (SessionWatch_CheckDialogTimeOut(coReturn))
*					{
*						return false;
*					}
*					//continue processing if no timeout
*
*****************************************************************************/
function SessionWatch_CheckDialogTimeOut(vstrReturnValue)
{
	if (vstrReturnValue == mstrDIALOG_RETURN_KILLSESSION)
	{
		SessionWatch_KillSession();
		return true;
	}
	return false;
}

/*****************************************************************************
* Purpose: Call this function to attach the SessionWatch_ResetTimer to events
*		   of elements on the form
* Input: vobjForm - reference to the form
*        vaFormElementData - two dimmensional array containing data on which
*					element types to attach to and which events to attach to
*
*****************************************************************************/
function SessionWatch_AttachReset(vobjForm, vaFormElementData)
{
	var inxForm;		//loop index for elements on form
	var inxArray;		//loop index for array data
	var strEvent = "";	//Holds the event

//Constants for second dimmension array index	
	var ELEMENT_TYPE = 0;	//location of element type
	var ELEMENT_EVENT = 1;	//location of event to attach 

//For each element on the form, attach reset timer function to applicable events
//Cross browser support included
	for (inxForm=0; inxForm < vobjForm.length; inxForm++)
	{
		for (inxArray=0; inxArray < vaFormElementData.length; inxArray++)
		{
			if (vobjForm.elements[inxForm].type == vaFormElementData[inxArray][ELEMENT_TYPE])
			{
				strEvent = vaFormElementData[inxArray][ELEMENT_EVENT];
				strEvent = (strEvent.substr(0,2) == "on")?strEvent.substr(2):strEvent;
				
				if (window.addEventListener)
				{
					vobjForm.elements[inxForm].addEventListener(strEvent, SessionWatch_ResetTimer,false);	
				}
				else if (window.attachEvent)
				{
					vobjForm.elements[inxForm].attachEvent("on" + strEvent, SessionWatch_ResetTimer);	
				}				
			}
		}
	}
}

/********************* End Session Timeout Routines **************************/
 
//-->   
</script>