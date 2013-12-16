using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace Conveyor_JSONRPC_API
{
    namespace Types
    {
        /*
         *  absolute-directory-path :: (string)
         *  
         *  An absolute directory path.
         */
        /* Commented out since API Class is indistingishable from a native type
        public class absolutedirectorypath : String
        {

        }
         */

        /*
         *  absolute-file-path :: (string)
         *  
         *  An absolute file path.
         */
        /* Commented out since API Class is indistingishable from a native type
        public class absolutefilepath : string
        {
            public string value { get; set; }
        }
         */

        /*
         *  archive-level :: (string)
         *  
         * An archive level.
         * Two archive levels are defined:
         * 
         * null
         * "all"
         */
        public enum archivelevel
        {
            //[StringValue(null)]
            NULL,
            //[StringValue("all")]
            all
        }

        /*
         *  connection-status :: (string)
         *  
         * The connection status.
         * There are two connection statuses defined:
         * 
         * "connected"
         * "notConnected"
         */
        public enum connectionstatus
        {
            //[StringValue("connected")]
            connected,
            //[StringValue("notConnected")]
            notConnected
        }

        /*
         *  job
         *  
         * { "rpcid": (job-rpcid)
         * , "name": (job-name)
         * , "state": (job-state)
         * , "conclusion": (job-conclusion)
         * , "currentstep": (job-step)
         * }
         */
        public class job
        {
            public int rpcid { get; set; }
            public string name { get; set; }
            public jobstate state { get; set; }
            public jobconclusion conclusion { get; set; }
            public jobstep concurrentstep { get; set; }
        }

        /*
         *  job-conclusion :: (string)
         *  
         * How drpcid the job conclude?
         * four conclusions are defined:
         * 
         * null (meaning not concluded)
         * "ENDED"
         * "FAILED"
         * "CANCELED"
         */
        public enum jobconclusion
        {
            //[StringValue(null)] 
            NULL, 
            //[StringValue("ENDED")] 
            ENDED,
            //[StringValue("FAILED")]
            FAILED,
            //[StringValue("CANCELED")] 
            CANCELED
        }

        /*
         *  job-rpcid :: (number)
         *  
         * A job rpcidentifier.
         */
        /* Commented out since API Class is indistingishable from a native type
        public class jobrpcid : int
        {
            //public int value { get; set; }
        }
         */

        /*
         *  job-name :: (string)
         *  
         * A job name, human-readable.
         */
        /* Commented out since API Class is indistingishable from a native type
        public class jobname : string
        {
            //public string value { get; set; }
        }
         */

        /*
         * job-state :: (string)
         * 
         * A job's state.
         * There are three states defined:
         * 
         * "PENDING"
         * "RUNNING"
         * "STOPPED"
         */
        public enum jobstate
        {
            //[StringValue("PENDING")] 
            PENDING, 
            //[StringValue("RUNNING")] 
            RUNNING,
            //[StringValue("STOPPED")] 
            STOPPED
        }

        /*
         *  job-step
         *  
         * { "name": (job-step-name)
         * , "progress": (number)
         * }
         */
        public class jobstep
        {
            public jobstepname name { get; set; }
            public double progress { get; set; }
        }

        /*
         *  job-step-name :: (string)
         *  
         * The name of a job step, e.g "slicing", "printing".
         */
        public enum jobstepname
        {
            //[StringValue("slicing")] 
            slicing, 
            //[StringValue("printing")] 
            printing
        }

        /*
         *  material-name :: (string)
         *  
         * A material name.
         */
        /* Commented out since API Class is indistingishable from a native type
        public class materialname : string
        {
            //public string value { get; set; }
        }
         */

        /*
         *  preprocessors
         *  
         * [ (preprocessor-name)
         * , ...
         * ]
         */
        /*
         *Class is redundant representation of an array object
         *
     public class preprocessors
     {
         public string[] values { get; set; }
     }*/

        /*
         *  preprocessor-name :: (string)
         *  
         * A preprocessor name.
         */
        /* Commented out since API Class is indistingishable from a native type
        public class preprocessorname : string
        {
            //public string value { get; set; }
        }
         */

        /*
         *  printer
         *  
         * { "profilename":       (profile-name)
         * , "displayname":       (string)
         * , "uniquename":        (printer-unique-name)
         * , "printertype":       (string)
         * , "canprint":          (bool)
         * , "canprinttofile":    (bool)
         * , "hasheatedplatform": (bool)
         * , "numberoftoolheads": (number)
         * , "connectionstatus":  (connection-status)
         * , "temperature":       (tool-temperatures)
         * }
         */
        public class printer
        {
            public string profilename { get; set; }
            public string displayname { get; set; }
            public string uniquename { get; set; }
            public string printertype { get; set; }
            public bool canprint { get; set; }
            public bool canprinttofile { get; set; }
            public bool hasheatedplatform { get; set; }
            public int numberoftoolheads { get; set; }
            public connectionstatus connectionstatus { get; set; }
            public  tooltemperatures temperature { get; set; }
        }

        /*
         * printer-unique-name :: (string)
         * 
         * A unique name to rpcidentify a unique printer.
         */
        /* Commented out since API Class is indistingishable from a native type
        public class printeruniquename : string
        {
            //public string value { get; set; }
        }
         */

        /*
         * profile-name :: (string)
         * 
         * A profile name.
         */
        /* Commented out since API Class is indistingishable from a native type
        public class profilename : string
        {
            //public string value { get; set; }
        }
         */

        /*
         *  rate :: (number)
         *  
         * A travel rate.
         */
        /* Commented out since API Class is indistingishable from a native type
        public class rate : double
        {
            //public double value { get; set; }
        }
         */

        /*
         * slicer-name :: (string)
         * 
         * A slicer name.
         */
        /* Commented out since API Class is indistingishable from a native type
        public class slicername : string
        {
            //public string value { get; set; }
        }
         */
    //
        
        /*
         * extruder-name :: (string)
         * 
         * An extruder name.
         */
        /* Commented out since API Class is indistingishable from a native type
        public class extrudername : string
        {
            //public string value { get; set; }
        }
         */

        /*
         *  slicer-settings :: (string)
         *  
         * A slicer settings object.
         * 
         * { 'slicer':               (slicer-name)
         * , 'extruder':             (extruder-name)
         * , 'raft':                 (bool)
         * , 'support':              (bool)
         * , 'infill':               (number)
         * , 'layer_height':         (number)
         * , 'shells':               (number)
         * , 'extruder_temperature': (temperature)
         * , 'platform_temperature': (temperature)
         * , 'print_speed':          (rate)
         * , 'travel_speed':         (rate)
         * }
         */
        public class slicersettings
        {
            public string slicer { get; set; }
            public string extruder { get; set; }
            public bool raft { get; set; }
            public bool support { get; set; }
            public double infill { get; set; }
            public double layer_height { get; set; }
            public double shells { get; set; }
            public double extruder_temperature { get; set; }
            public double platform_temperature { get; set; }
            public double print_speed { get; set; }
            public double travel_speed { get; set; }
        }

        /*
         *  temperature :: (number)
         *  
         * A temperature.
         */
        /* Commented out since API Class is indistingishable from a native type
        public class temperature : double
        {
            //public string value { get; set; }
        }
         */

        /*
         *   tool-name :: (string)
         *   
         * The name of a tool or heated build platform on the printer. These are ordinarily numbers represented as strings.
         */
        /* Commented out since API Class is indistingishable from a native type
        public class toolname : string
        {
            //public string value { get; set; }
        }
         */

        /*
         *   tool-temperatures :: (string)
         *   
         * A list of temperatures for all toolheads and heated build platforms on the printer.
         * 
         * { "tools" :
         * { (tool-name) : 
         * (temperature)
         * , ...
         * }
         * , "heated_platforms" :
         * { (tool-name) : 
         * (temperature)
         * , ...
         * }
         * }
         */
        public class tooltemperatures
        {
            //public string value { get; set; }
            public tool[] tools { get; set; }
            public tool[] heated_platforms { get; set; }
        }

        /*
         *  tool :: (tool)
         *  
         * implicit class created to account for object in tooltemperatures object.
         * 
         * { 'toolname':               (tool-name)
         * , 'temperature':             (temperature)}
         */
        public class tool
        {
            public string toolname { get; set; }
            public double temperature { get; set; }
        }
    }

    /*
     * The server only ever makes JSON-RPC notification calls to the client. 
     * It never expects a response. The result for any of the client API methods is 'null'.
     */
    public static class ClientAPI
    {
        /*
         * printeradded
         * The server invokes this method when a new printer is connected.
         * params
         * (printer)
         */
        public static string PrinterAdded(int rpcid)
        {
            throw new NotImplementedException();
            List<string> Params = new List<string>();
            //Params.Add();
            return BuildRPCString(rpcid, "print");
        }

        /*
         * printerremoved
         * The server invokes this method when a printer is disconnected.
         * params
         * (printer)
         */
        public static string PrinterRemoved(int rpcid)
        {
            throw new NotImplementedException();
            List<string> Params = new List<string>();
            //Params.Add();
            return BuildRPCString(rpcid, "print");
        }

        /*
         * printerchanged
         * The server invokes this method when a printer changes.
         * params
         * (printer)
         */
        public static string PrinterChanged(int rpcid)
        {
            throw new NotImplementedException();
            List<string> Params = new List<string>();
            //Params.Add();
            return BuildRPCString(rpcid, "print");
        }

        /*
         * jobadded
         * 
         * The server invokes this method whenever a new job is added.
         * 
         * params
         * 
         * (job)
         */
        public static string JobAdded(int rpcid)
        {
            throw new NotImplementedException();
            List<string> Params = new List<string>();
            //Params.Add();
            return BuildRPCString(rpcid, "print");
        }

        /*
         * jobchanged
         * The server invokes this method whenever a job changes.
         * params
         * (job)
         */
        public static string JobChanged(int rpcid)
        {
            throw new NotImplementedException();
            List<string> Params = new List<string>();
            //Params.Add();
            return BuildRPCString(rpcid, "print");
        }

        /*
         * jobremoved
         * The server invokes this method after a job finishes.
         * params
         * (job)
         */
        public static string JobRemoved(int rpcid)
        {
            throw new NotImplementedException();
            List<string> Params = new List<string>();
            //Params.Add();
            return BuildRPCString(rpcid, "print");
        }

        private static string BuildRPCString(int rpcid, string MethodName)
        {
            return BuildRPCString(rpcid, MethodName, new List<object>());
        }

        private static string BuildRPCString(int rpcid, string MethodName, List<object> Params)
        {
            JObject rpcCall = new JObject();
            rpcCall.Add(new JProperty("jsonrpc", "2.0"));
            rpcCall.Add(new JProperty("id", rpcid.ToString()));
            rpcCall.Add(new JProperty("method", MethodName));
            //rpcCall.Add(new JProperty("method", "add"));


            // params is a collection values which the method requires..
            if (Params.Count == 0)
            {
                rpcCall.Add(new JProperty("params", new JArray()));
            }
            else
            {
                JArray props = new JArray();
                // add the props in the reverse order!
                foreach (string param in Params)
                {
                    // add the params
                    props.Add(param);
                }
                rpcCall.Add(new JProperty("params", props));
            }

            // serialize json for the request
            return JsonConvert.SerializeObject(rpcCall);
        }
    }

    /*
     * This Class is a list of static methods to generate RPC commands and return their replies.
     */
    public class ServerAPI
    {
        /*
         * hello
         * This method *MUST* be called exactly once when a client first connects to conveyor. 
         * Clients *MUST* not invoke any other methods before calling hello.
         * 
         * Clients *MUST* not invoke hello more than once.
         * params
         * {            }
         * result
         * "world"
         * 
         * @param int rpcid : This is the rpcidentification number of the rpc method, since the server can reply asyncronously.
         */
        public static string Hello(int rpcid)
        {
            return BuildRPCString(rpcid, "hello");
        }

        /*
         * print
         * This method creates and starts a print job.
         * params
         * { 
         * "uniquename":      (printer-unique-name)            
         * , "inputpath":       (absolute-file-path)            
         * , "preprocessor":    (preprocessors)            
         * , "skip_start_end":  (bool)            
         * , "archive_lvl":     (archive-level)            
         * , "archive_dir:"     (absolute-directory-path)            
         * , "slicer_settings": (slicer-settings)            
         * , "material":        (material-name)            
         * }
         * result
         * (job)
         */
        public static string Print(int rpcid)
        {
            throw new NotImplementedException();
            List<string> Params = new List<string>();
            //Params.Add();
            return BuildRPCString(rpcid, "print");
        }

        /*
         * printtofile
         * This method creates and starts a print-to-file job.
         * The "printername" field name and type should be changed to "profilename" and (profile-name).
         * params
         * { "profilename":     (profile-name)            
         * , "inputpath":       (absolute-file-path)            
         * , "outputpath":      (absolute-file-path)            
         * , "preprocessor":    (preprocessors)            
         * , "skip_start_end":  (bool)            
         * , "archive_lvl":     (archive-level)            
         * , "archive_dir:"     (absolute-directory-path)            
         * , "slicer_settings": (slicer-settings)            
         * , "material":        (material-name)            
         * }
         * result
         * (job)
         */
        public static string PrintToFile(int rpcid)
        {
            throw new NotImplementedException();
            List<string> Params = new List<string>();
            //Params.Add();
            return BuildRPCString(rpcid, "printtofile");
        }

        /*
         * slice
         * This method creates and starts a slice job.
         * params
         * { "profilename":     (profile-name)            
         * , "inputpath":       (absolute-file-path)            
         * , "outputpath":      (absolute-file-path)            
         * , "preprocessor":    (preprocessors)            
         * , "skip_start_end":  (bool)            
         * , "archive_lvl":     (archive-level)            
         * , "archive_dir:"     (absolute-directory-path)            
         * , "slicer_settings": (slicer-settings)            
         * , "material":        (material-name)            
         * }
         *  result
         *  (job)
         */
        public static string Slice(int rpcid)
        {
            throw new NotImplementedException();
            List<string> Params = new List<string>();
            //Params.Add();
            return BuildRPCString(rpcid, "slice");
        }

        /*
         * canceljob
         * This method schedules a job for cancellation.        
         * The job may or may not be canceled when this method returns.
         * 
         * params
         * { "rpcid": (job-rpcid)            
         * }
         * result
         * null
         */
        public static string CancelJob(int rpcid, int jobid)
        {
            List<object> Params = new List<object>();
            Params.Add(jobid.ToString());
            return BuildRPCString(rpcid, "canceljob", Params);
        }

        /*
         * getprinter
         * This method returns the details for a printer.
         * params
         * { "uniquename": (printer-unique-name)            
         * }
         * result
         * (printer)
         */
        public static string GetPrinter(int rpcid, string uniquename)
        {
            List<object> Params = new List<object>();
            Params.Add(uniquename);
            return BuildRPCString(rpcid, "getprinter", Params);
        }

        /*
         * getprinters
         * This method returns the list of printers.
         * params
         * {            
         * }
         * result
         * [ (printer)            
         * , ...            
         * ]
         */
        public static string GetPrinters(int rpcid)
        {
            return BuildRPCString(rpcid, "getprinters");
        }

        /*
         * getjob
         * This method returns the details for a job.
         * params
         * { "rpcid": (job-rpcid)            
         * }
         * result
         * (job)
         */
        public static string GetJob(int rpcid)
        {
            throw new NotImplementedException();
            List<string> Params = new List<string>();
            //Params.Add();
            return BuildRPCString(rpcid, "print");
        }

        /*
         * getjobs
         * 
         * This method returns the list of jobs.
         * 
         * params
         * 
         * {
         * }
         * 
         * result
         * 
         * [ (job)
         * , ...
         * ]
         */
        public static string GetJobs(int rpcid)
        {
            throw new NotImplementedException();
            List<string> Params = new List<string>();
            //Params.Add();
            return BuildRPCString(rpcid, "print");
        }

        /*
         * dir
         */
        public static string Dir(int rpcid)
        {
            throw new NotImplementedException();
            List<string> Params = new List<string>();
            //Params.Add();
            return BuildRPCString(rpcid, "print");
        }

        /*
         * printer\_query
         */
        public static string Printer_Query(int rpcid)
        {
            throw new NotImplementedException();
            List<string> Params = new List<string>();
            //Params.Add();
            return BuildRPCString(rpcid, "print");
        }

        /*
         * printer\_scan
         */
        public static string Printer_Scan(int rpcid)
        {
            throw new NotImplementedException();
            List<string> Params = new List<string>();
            //Params.Add();
            return BuildRPCString(rpcid, "print");
        }

        private static string BuildRPCString(int rpcid, string MethodName)
        {
            return BuildRPCString(rpcid, MethodName, new List<object>());
        }

        private static string BuildRPCString(int rpcid, string MethodName, List<object> Params)
        {
            JObject rpcCall = new JObject();
            rpcCall.Add(new JProperty("jsonrpc", "2.0"));
            rpcCall.Add(new JProperty("id", rpcid.ToString()));
            rpcCall.Add(new JProperty("method", MethodName));
            //rpcCall.Add(new JProperty("method", "add"));


            // params is a collection values which the method requires..
            if (Params.Count == 0)
            {
                rpcCall.Add(new JProperty("params", new JArray()));
            }
            else
            {
                JArray props = new JArray();
                // add the props in the reverse order!
                foreach (string param in Params)
                {
                    // add the params
                    props.Add(param);
                }
                rpcCall.Add(new JProperty("params", props));
            }

            // serialize json for the request
            return JsonConvert.SerializeObject(rpcCall);
        }
    }

    /*
     *  jsonrpcresult
     *  
     * object to encapsulate messages from the server, which will be formatted in an rpc syntax
     * 
     */
    public class JsonRpcResult<T>
    {
        //Example Reply	"{\"jsonrpc\": \"2.0\", \"result\": \"world\", \"rpcid\": \"2\"}"	string
        public double jsonrpc { get; set; }
        //public string result { get; set; }
        public T result { get; set; }
        public int rpcid { get; set; }
    }
}
