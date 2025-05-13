import React, { useEffect, useState } from 'react';
import { useParams } from 'react-router-dom';

const PersonalArea = () => {
  const { id } = useParams();
  const [customerDetails, setCustomerDetails] = useState(null);
  const [workerDetails, setWorkerDetails] = useState(null);
  const [appointments, setAppointments] = useState([]); // מצב לשמירת התורים
  const [error, setError] = useState('');
  const [showDetails, setShowDetails] = useState(false); // מצב להצגת פרטים
  const [showAppointments, setShowAppointments] = useState(false); // מצב להצגת תורים

  useEffect(() => {
    const fetchData = async () => {
      try {
        // בדיקה אם תעודת הזהות שייכת ללקוח
        const customerResponse = await fetch(`http://localhost:5067/api/Customer/check/${id}`);
        if (customerResponse.ok) {
          const customerData = await customerResponse.json();
          setCustomerDetails(customerData);
          setError('');
          return; // יציאה אם נמצא כלקוח
        }

        // בדיקה אם תעודת הזהות שייכת לעובד
        const workerResponse = await fetch(`http://localhost:5067/api/Worker/check/${id}`);
        if (workerResponse.ok) {
          const workerData = await workerResponse.json();
          setWorkerDetails(workerData);
          setError('');
          return; // יציאה אם נמצא כעובד
        }

        // אם לא נמצא כלקוח או עובד
        setError('לא נמצא לקוח או עובד עם תעודת הזהות שהוזנה.');
        setCustomerDetails(null);
        setWorkerDetails(null);
      } catch (err) {
        console.error(err);
        setError('שגיאה בשרת');
      }
    };

    fetchData();
  }, [id]);

  const handleShowDetails = () => {
    setShowDetails(true);
    setShowAppointments(false); // ודא שתורים לא מוצגים באותו זמן
  };

  const handleShowAppointments = async () => {
    setShowAppointments(true);
    setShowDetails(false); // ודא שפרטים אישיים לא מוצגים באותו זמן
    try {
      const response = await fetch(`http://localhost:5067/api/Customer/${id}/appointments`);
      if (response.ok) {
        const data = await response.json();
        setAppointments(data);
        setError('');
      } else {
        const errorData = await response.json();
        setError(errorData.message || 'שגיאה בטעינת התורים');
      }
    } catch (err) {
      console.error(err);
      setError('שגיאה בשרת');
    }
  };

  return (
    <div style={styles.container}>
      <h1 style={styles.title}>אזור אישי</h1>
      {error && <p style={{ color: 'red' }}>{error}</p>}
      {!error && (
        <div>
          {!showDetails && !showAppointments && (
            <div>
              <button onClick={handleShowDetails} style={styles.button}>
                לצפייה בפרטים
              </button>
              <button onClick={handleShowAppointments} style={styles.button}>
                לצפייה בתורים
              </button>
            </div>
          )}
          {showDetails && customerDetails && (
            <div>
              <h2>פרטי לקוח</h2>
              <p>ת.ז: {customerDetails.id}</p>
              <p>שם מלא: {customerDetails.firstName}</p>
              <p>טלפון: {customerDetails.phone}</p>
              <h3>פעולות מורשות ללקוח</h3>
              <ul>
                <li>צפייה בפגישות</li>
                <li>עדכון פרטים</li>
              </ul>
            </div>
          )}
          {showDetails && workerDetails && (
            <div>
              <h2>פרטי עובד</h2>
              <p>ת.ז: {workerDetails.id}</p>
              <p>שם מלא: {workerDetails.firstName}</p>
              <p>תפקיד: {workerDetails.specialty}</p>
              <h3>פעולות מורשות לעובד</h3>
              <ul>
                <li>ניהול פגישות</li>
                <li>עדכון פרטי לקוחות</li>
              </ul>
            </div>
          )}
          {showAppointments && (
            <div>
              <h2>רשימת תורים</h2>
              {appointments.length > 0 ? (
                <ul>
                  {appointments.map((appointment) => (
                    <li key={appointment.id}>
                      תור #{appointment.id} - תאריך: {new Date(appointment.date).toLocaleDateString()} - שעה: {new Date(appointment.date).toLocaleTimeString()}
                    </li>
                  ))}
                </ul>
              ) : (
                <p>אין תורים להצגה</p>
              )}
            </div>
          )}
        </div>
      )}
    </div>
  );
};

const styles = {
  container: {
    textAlign: 'center',
    marginTop: '50px',
  },
  title: {
    fontSize: '36px',
    fontWeight: 'bold',
    marginBottom: '20px',
  },
  button: {
    backgroundColor: '#4CAF50',
    color: 'white',
    padding: '10px 20px',
    fontSize: '18px',
    border: 'none',
    cursor: 'pointer',
    marginTop: '20px',
    marginRight: '10px',
  },
};

export default PersonalArea;