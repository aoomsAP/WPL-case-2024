import { useEffect, useCallback } from 'react';
import { useNavigate } from 'react-router-dom';

// Custom hook to block navigation & fire a warning dialog to confirm

export const useLeaveWarning = (when: boolean, message: string) => {
  const navigate = useNavigate();

  const blockNavigation = useCallback(
    (nextLocation: any) => {
      // Show confirmation dialog
      const confirm = window.confirm(message);

      // If user confirms, proceed with navigation if user confirms
      if (confirm) {
        navigate(nextLocation.pathname); 
      }
    },
    [message, navigate]
  );

  useEffect(() => {
    // Do nothing if set to false
    if (!when) return; 

    // Handle the browser's "beforeunload" event (user tries to close or refresh the tab)
    const handleBeforeUnload = (event: BeforeUnloadEvent) => {
      event.preventDefault();

      // Standardized message across browsers (! Most browsers show a generic message)
      event.returnValue = message;
    };

    // Attach the beforeunload event to handle browser/tab close
    window.addEventListener('beforeunload', handleBeforeUnload);

    // Cleanup when component unmounts or when 'when' changes
    return () => {
      window.removeEventListener('beforeunload', handleBeforeUnload);
    };
  }, [message, when]);

  return blockNavigation; // Return the navigation block function
};
