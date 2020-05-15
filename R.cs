using System;

namespace RitramaAPP
{
    public class R
    {
        public class SERVERS
        {
            public static string SERVER_ETIQUETAS = "SERVER-ETIQUETA";
            public static string SERVER_RITRAMA = "RITRAMASRV01";
        }
        public class DATABASES 
        {
            public static string RITRAMA = "RITRAMA";
        }
        public class USERS
        {
            public static string UserMaster = "Npino";
            public static string KeyMaster = "Jossycar5%";
        }

        public class SQL
        {
            
            public class DATABASE
            {
                public static string NAME = "ritrama";

            }
            public class TABLES
            {
                public static string TABLE_RECEPCION = "OrdenRecepcion";
                public static string TABLE_MASTERS_INIC = "MasterInic";
                public static string TABLE_HOJAS_INIC = "HojasInic";
                public static string TABLE_GRAPHICS_INIC = "GraphicsInic";
                public static string TABLE_PRODUCTS = "producto";
                public static string TABLE_CUSTOMERS = "Customer";
            }
            public class QUERY_SQL
            {
                public class PRODUCTS
                {
                    public static string SQL_QUERY_SELECT_PRODUCT_ALL = "SELECT Product_ID,Product_Name,Product_Descrip,Product_Ref,Codebar,Category_ID,MasterRolls,rollo_cortado,Resmas,anulado,precio,graphics,code_RC,ratio,case when MasterRolls = 1 then 'Master' when rollo_cortado = 1 then 'Rollo Cortado' when Graphics = 1 then 'Graphics' when Resmas = 1 then 'Hojas' else 'sin tipo' end as tipo FROM producto";
                    public static string SQL_QUERY_SELECT_PRODUCTS = "SELECT Product_ID, Product_Name,case when MasterRolls = 1 then 'Master' when rollo_cortado = 1 then 'Rollo Cortado' when Graphics = 1 then 'Graphics' when Resmas = 1 then 'Hojas' else 'sin tipo' end as tipo FROM producto";
                    public static string SQL_QUERY_SELECT_TYPE_PRODUCT = "SELECT MasterRolls,rollo_cortado,Resmas,Graphics FROM producto WHERE product_id=@p1";
                    public static string SQL_QUERY_SELECT_PRODUCT_NAME = "SELECT  Product_Name FROM producto WHERE product_id=@p1";
                    public static string SQL_QUERY_INSERT_PRODUCT = "INSERT INTO producto (Product_ID,Product_Name,Product_Descrip,Product_Ref,Codebar,Category_ID,MasterRolls,rollo_cortado,Resmas,Graphics,anulado,precio,code_RC,ratio) VALUES (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11,@p12,@p13,@p14)";
                    public static string SQL_QUERY_UPDATE_PRODUCTS = "UPDATE producto SET Product_Name=@p2,Product_Descrip=@p3,Product_Ref=@p4,Codebar=@p5,Category_ID=@p6,Resmas=@p9,Graphics=@p10,anulado=@p11,precio=@p12,ratio=@p14 WHERE Product_ID=@p1";
                    public static string SQL_QUERY_COUNT_PRODUCTS = "SELECT count(*) FROM producto WHERE product_id=@p1";
                    public static string SQL_QUERY_CATEGORY_PRODUCTS = "select case when MasterRolls = 1 then 'Master' when rollo_cortado = 1 then 'Rollo Cortado' when Graphics = 1 then 'Graphics' when Resmas = 1 then 'Hojas' else 'sin tipo' end from producto where Product_ID=@p1";
                }
                public class CUSTOMERS
                {
                    public static string SQL_SELECT_CUSTOMERS = "SELECT Customer_ID,Customer_Name,Customer_Category," +
                        "Customer_Dir,Customer_Email,Anulado  FROM customer";
                }

                public class PROVIDERS
                {
                    public static string SQL_QUERY_SELECT_PROVIDER_ONLY_TABLE = "";
                    public static string SQL_QUERY_SELECT_PROVEEDORES = "SELECT Proveedor_ID,Proveedor_Name,Preveedor_phone,Preveedor_Dir,Preveedor_email,anulado,unidad_master_1,unidad_master_2 FROM provider";
                    public static string SQL_QUERY_INSERT_PROVEEDORES = "INSERT INTO provider (Proveedor_ID,Proveedor_Name,Preveedor_Dir,Preveedor_phone,Preveedor_email,anulado,unidad_master_1,unidad_master_2) VALUES (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8)";
                    public static string SQL_QUERY_UPDATE_PROVEEDORES = "UPDATE provider SET Proveedor_Name=@p2,Preveedor_Dir=@p3,Preveedor_phone=@p4,Preveedor_email=@p5,anulado=@p6,unidad_master_1=@p7,unidad_master_2=@p8 WHERE Proveedor_ID=@p1";
                    public static string SQL_QUERY_COUNT_PROVEEDORES = "SELECT count(*) FROM provider WHERE proveedor_id=@p1";
                }

                public class RECEPCIONES
                {
                    public static string SQL_QUERY_SELECT_ORDENES_RECEPCION = "SELECT OrderPurchase,Part_Number,Width,Lenght," +
                        "Roll_Id,Proveedor_Id,Splice,Core,Ubicacion,anulado,fecha_reg,hora_reg,fecha_pro,master,resma,graphics," +
                        "embarque,palet_num,palet_cant,palet_pag,num_sincro,registro_movil,width_metros,lenght_metros,fecha_recep FROM "
                        + TABLES.TABLE_RECEPCION +
                        " order by CONVERT(INT ,OrderPurchase)";

                    public static string SQL_QUERY_SELECT_INICIALES_MASTERS = "SELECT * FROM (SELECT OrderPurchase, Part_Number, Width, lenght,lenght-lenght_c AS lenght_p,lenght_c,Roll_Id, Proveedor_Id, " +
                    "Splice, Core, Ubicacion, anulado,fecha_reg, hora_reg, fecha_pro, master, resma, graphics,embarque, palet_num, palet_cant, palet_pag, num_sincro, " +
                    "registro_movil, width_metros, lenght_metros, fecha_recep,'I' AS tipo_mov,status,master_load,doc_oc FROM MasterInic WHERE disponible = 1 UNION SELECT OrderPurchase, Part_Number, " +
                    "Width, Lenght,lenght-lenght_c AS lenght_p,lenght_c,Roll_Id, Proveedor_Id, Splice, Core, Ubicacion, anulado,fecha_reg, hora_reg, fecha_pro, master, resma, graphics,embarque, palet_num, " +
                    "palet_cant, palet_pag, num_sincro,registro_movil, width_metros, lenght_metros, fecha_recep,'M' AS tipo_mov,status,master_load,doc_oc FROM OrdenRecepcion WHERE disponible = 1 AND master = 1) " +
                    "T ORDER BY CONVERT(INT , OrderPurchase)";

                    public static string SQL_QUERY_SELECT_INICIALES_HOJAS = "SELECT * FROM(SELECT OrderPurchase, Part_Number, Width, Lenght, Roll_Id, Proveedor_Id, Splice,Core, Ubicacion, anulado, fecha_reg," +
                    "hora_reg, fecha_pro, master, resma, graphics, embarque,palet_num, palet_cant, palet_pag as hojas, paletpag_c as hojas_parc, palet_pag - paletpag_c as hojas_saldo,num_sincro, registro_movil," +
                    "width_metros,lenght_metros, fecha_recep, 'M' AS tipo_mov, disponible,status FROM OrdenRecepcion  WHERE disponible = 1 and resma = 1 UNION SELECT OrderPurchase, Part_Number, Width, Lenght, Roll_Id," +
                    "Proveedor_Id, Splice,Core, Ubicacion, anulado, fecha_reg, hora_reg, fecha_pro, master, resma, graphics, embarque, palet_num,palet_cant, palet_pag as hojas, paletpag_c as hojas_parc," +
                    "palet_pag - paletpag_c as hojas_saldo, num_sincro, registro_movil, width_metros,lenght_metros, fecha_recep, 'I' AS tipo_mov, disponible,status FROM HojasInic) T WHERE T.disponible=1 " +
                    "ORDER BY CONVERT(INT , Roll_Id)";

                    public static string SQL_QUERY_SELECT_INICIALES_GRAPHICS = "SELECT * FROM (SELECT OrderPurchase, Part_Number, Width, Lenght,Roll_Id, Proveedor_Id, Splice, Core, " +
                    "Ubicacion, anulado, fecha_reg, hora_reg, fecha_pro, master, resma, graphics, embarque, palet_num, palet_cant, palet_pag, num_sincro, " +
                    "registro_movil, width_metros, lenght_metros, fecha_recep,'M' AS tipo_mov,status FROM OrdenRecepcion WHERE disponible = 1 AND graphics = 1 UNION SELECT OrderPurchase, " +
                    "Part_Number, Width, Lenght,Roll_Id, Proveedor_Id, Splice, Core, Ubicacion, anulado,fecha_reg, hora_reg, fecha_pro, master, resma, graphics,embarque, palet_num, " +
                    "palet_cant, palet_pag, num_sincro,registro_movil, width_metros, lenght_metros, fecha_recep,'I' AS tipo_mov,status FROM GraphicsInic WHERE disponible = 1) T " +
                    "ORDER BY roll_id DESC";



                    public static string SQL_QUERY_COUNT_FOR_ORDER = "SELECT count(*) FROM OrdenRecepcion WHERE" +
                        " OrderPurchase=@p1";

                    public static string SQL_QUERY_VERIFICAR_ROLLID = "SELECT count(*) FROM OrdenRecepcion WHERE" +
                       " roll_id=@p1";

                    public static string SQL_QUERY_COUNT_FOR_VERIFY_UNIT2 = "SELECT unidad_master_2 FROM provider WHERE Proveedor_ID=" +
                        "@p1";
                    public static string SQL_QUERY_UPDATE_ORDEN_RECEPCION = "UPDATE OrdenRecepcion SET fecha_pro=@p2,embarque=@p3," +

                        "Roll_Id=@p4,anulado=@p5,ubicacion=@p6,Proveedor_Id=@p7,width=@p8,lenght=@p9,splice=@p10,core=@p11,width_metros=@p12,lenght_metros=@p13,fecha_recep=@p14 " +
                        "WHERE OrderPurchase=@p1";

                    public static string SQL_QUERY_INSERT_DOCS_RECEPCIONES = "INSERT INTO " + TABLES.TABLE_RECEPCION +
                    " (OrderPurchase,Part_Number,Width,Lenght,Roll_Id,Proveedor_Id,Ubicacion,Core,Splice,Anulado,fecha_reg,hora_reg," +
                    "fecha_pro,master,resma,graphics,embarque,palet_num,palet_cant,palet_pag,num_sincro,registro_movil,disponible,width_metros,lenght_metros,fecha_recep,width_c,lenght_c) " +
                    "VALUES (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11,@p12,@p13,@p14," +
                    "@p15,@p16,@p17,@p18,@p19,@p20,@p21,@p22,@p23,@p24,@p25,@p26,0,0)";

                    public static string SQL_QUERY_INSERT_INICIALES_MASTERS = "INSERT INTO " + TABLES.TABLE_MASTERS_INIC +
                    " (OrderPurchase,Part_Number,Width,Lenght,Roll_Id,Proveedor_Id,Ubicacion,Core,Splice,Anulado,fecha_reg,hora_reg," +
                    "fecha_pro,master,resma,graphics,embarque,palet_num,palet_cant,palet_pag,num_sincro,registro_movil,disponible,width_metros,lenght_metros,fecha_recep,width_c,lenght_c) " +
                    "VALUES (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11,@p12,@p13,@p14," +
                    "@p15,@p16,@p17,@p18,@p19,@p20,@p21,@p22,@p23,@p24,@p25,@p26,0,0)";

                    public static string SQL_QUERY_INSERT_INICIALES_HOJAS = "INSERT INTO " + TABLES.TABLE_HOJAS_INIC +
                   " (OrderPurchase,Part_Number,Width,Lenght,Roll_Id,Proveedor_Id,Ubicacion,Core,Splice,Anulado,fecha_reg,hora_reg," +
                   "fecha_pro,master,resma,graphics,embarque,palet_num,palet_cant,palet_pag,num_sincro,registro_movil,disponible,width_metros,lenght_metros,fecha_recep,width_c,lenght_c) " +
                   "VALUES (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11,@p12,@p13,@p14," +
                   "@p15,@p16,@p17,@p18,@p19,@p20,@p21,@p22,@p23,@p24,@p25,@p26,0,0)";

                    public static string SQL_QUERY_INSERT_INICIALES_GRAPHICS = "INSERT INTO " + TABLES.TABLE_GRAPHICS_INIC +
                   " (OrderPurchase,Part_Number,Width,Lenght,Roll_Id,Proveedor_Id,Ubicacion,Core,Splice,Anulado,fecha_reg,hora_reg," +
                   "fecha_pro,master,resma,graphics,embarque,palet_num,palet_cant,palet_pag,num_sincro,registro_movil,disponible,width_metros,lenght_metros,fecha_recep,width_c,lenght_c) " +
                   "VALUES (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11,@p12,@p13,@p14," +
                   "@p15,@p16,@p17,@p18,@p19,@p20,@p21,@p22,@p23,@p24,@p25,@p26,0,0)";

                    public static string SQL_QUERY_VERIFY_ORDEN_REPEAT = "SELECT count(*) FROM OrdenRecepcion WHERE " +
                        "OrderPurchase=@p1";
                    public static string SQL_QUERY_RETURN_CONSENC_ORDEN = "select max(CONVERT(INT,OrderPurchase))+1 from OrdenRecepcion";
                    public static string SQL_QUERY_SELECT_GETDATABYID_HOJAS = "SELECT * FROM (SELECT a.Part_Number, b.Product_Name, a.Roll_Id," +
                    "a.Width, a.lenght, a.palet_num,a.palet_cant,a.palet_pag - a.paletpag_c AS palet_pag, 'M' AS tipo_mov,disponible FROM OrdenRecepcion a LEFT JOIN producto b " +
                    "ON a.Part_Number = b.Product_ID WHERE resma = 1 UNION SELECT a.Part_Number, b.Product_Name, a.Roll_Id, a.Width, a.lenght," +
                    "a.palet_num, a.palet_cant,a.palet_pag - a.paletpag_c AS palet_pag, 'I' AS tipo_mov,disponible FROM HojasInic a LEFT JOIN producto b ON a.Part_Number = b.Product_ID " +
                    "WHERE resma = 1) T WHERE T.Roll_Id=@p1 AND T.disponible=1";
                    public static string SQL_QUERY_SELECT_GETDATABYID_GRAPHICS = "SELECT * FROM (SELECT a.OrderPurchase, a.Part_Number, b.Product_Name, a.Width, a.Lenght, a.Roll_Id, a.Proveedor_Id," +
                    "a.palet_num, a.palet_pag, a.embarque, 'M' AS tipo_mov FROM OrdenRecepcion a LEFT JOIN producto b ON a.Part_Number = b.Product_ID WHERE a.graphics = 1 AND a.disponible=1 " +
                    "UNION SELECT a.OrderPurchase, a.Part_Number, b.Product_Name, a.Width, a.Lenght, a.Roll_Id, a.Proveedor_Id,a.palet_num, a.palet_pag, a.embarque, 'I' AS tipo_mov " +
                    "FROM GraphicsInic a LEFT JOIN producto b ON a.Part_Number = b.Product_ID WHERE a.graphics = 1 AND a.disponible=1) T WHERE T.Roll_Id=@p1";
                }
                public class PRODUCCION
                {
                    public static string SQL_SELECT_ORDEN_CORTE = "SELECT numero,fecha,fecha_produccion,product_id,rollid_1,width_1," +
                        "lenght_1,rollid_2,width_2,lenght_2,width_cortado,lenght_cortado,msi_cortado,anulada,Procesado,tot_inch_ancho,longitud_cortar," +
                        "cortes_ancho,cortes_largo,cant_rollos,decartable1_pies,lenght_master_real,util1_real_width,util1_real_lenght,rest1_width,rest1_lenght, " +
                        "util2_real_width,util2_real_lenght,descartable2_pies,lenght_master_real2,rest2_width,rest2_lenght,cortes_largo2,cant_rollos2,step,tipo_mov1,tipo_mov2 FROM orden_corte ORDER BY CONVERT(INT, numero) DESC";
                    public static string SQL_SELECT_DETALLE_OC = "SELECT reng_num,numero,product_id,cantidad,unidad,width,large,msi FROM  detalle_oc";
                    public static string SQL_UPDATE_ROLLS_DETAILS = "SELECT product_id,roll_number,unique_code,splice,width,large,product_name,roll_id,msi," +
                        "code_perso FROM rolls_details WHERE numero=@p1 and product_id=@p2";
                    public static string SQL_QUERY_INSERT_MASTER_OC = "INSERT orden_corte (numero,fecha,fecha_produccion,product_id,rollid_1,width_1,lenght_1," +
                        "rollid_2,width_2,lenght_2,anulada,Procesado,tot_inch_ancho,longitud_cortar,cortes_ancho,cortes_largo,cant_rollos,decartable1_pies,"+
                        "lenght_master_real,util1_real_width,util1_real_lenght,rest1_width,rest1_lenght,descartable2_pies,lenght_master_real2,util2_real_width,"+
                        "util2_real_lenght,rest2_width,rest2_lenght,Cortes_Largo2,cant_rollos2,step,tipo_mov1,tipo_mov2) " +
                        "VALUES (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11,@p12,@p13,@p14,@p15,@p16,@p17,@p18,@p19,@p20,@p21,@p22,@p23,@p24,@p25,@p26,@p27,@p28,@p29,@p30,@p31,1,@p32,@p33) ";
                    public static string SQL_QUERY_INSERT_DETAILS_OC = "INSERT rolls_details (numero,product_id,product_name,roll_number,unique_code,splice,width,large,msi,roll_id,code_person,status,disponible) " +
                        "VALUES (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11,@p12,@p13)";
                    public static string SQL_QUERY_INSERT_ROLL_INIC = "INSERT RollsInic (numero,product_id,product_name,roll_number,unique_code,splice,width,large,msi,roll_id,code_person,status,disponible) " +
                        "VALUES (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11,@p12,@p13)";
                    public static string SQL_QUERY_SELECT_ROLLID =
                    "select a.roll_id,a.part_number,b.product_name,a.master,a.graphics,a.resma,a.Width," +
                    "lenght=a.lenght - a.lenght_c, disponible, fecha_pro, fecha_recep, splice, Ubicacion,'M' AS tipo_mov from OrdenRecepcion a LEFT JOIN producto b ON a.part_number = b.product_id " +
                    "where b.MasterRolls = 1 and a.disponible = 1 UNION select a.roll_id, a.part_number, b.product_name, a.master, a.graphics, a.resma,a.Width," +
                    "lenght = a.lenght - a.lenght_c, disponible, fecha_pro, fecha_recep, splice, Ubicacion,'I' AS tipo_mov from MasterInic a " +
                    "LEFT JOIN producto b ON a.part_number = b.product_id where b.MasterRolls = 1 and a.disponible = 1 ORDER BY fecha_recep, splice ASC";
                    public static string SQL_QUERY_SELECT_ROLLOS_CORTADOS = "SELECT numero,product_id,product_name,roll_number,unique_code,splice,width,width_c,large,lenght_c,msi,roll_id,code_person,status FROM rolls_details ORDER BY roll_number";
                    public static string SQL_QUERY_SELECT_ROLLOS_CORTADOS_INIC = "SELECT * FROM (SELECT numero, product_id, product_name, roll_number,unique_code, " +
                    "splice, width, width_c, large, lenght_c,msi, roll_id, code_person, status, 'M' AS tipo_mov,ubic FROM rolls_details WHERE disponible = 1 UNION " +
                    "SELECT numero, product_id, product_name, roll_number, unique_code, splice, width, width_c, large, lenght_c,msi, roll_id, code_person, " +
                     "status, 'I' AS tipo_mov,ubic FROM RollsInic WHERE disponible = 1) T ORDER BY T.numero";
                    public static string SQL_QUERY_INSERT_ROLLID = "INSERT INTO roll_id (numero,roll_id) VALUES (@P1,@p2)";
                    public static string SQL_QUERY_INSERT_ROLLS_DETAILS = "INSERT rolls_details (fecha,numero,roll_number,product_id," +
                        "product_name,roll_id,width,large,msi,splice,code_perso,unique_code) VALUES (@r1,@r2,@r3,@r4,@r5,@r6,@r7,@r8,@r9,@r10,@r11,@r12)";
                    public static string SQL_QUERY_DELETE_ROLLID = "DELETE roll_id WHERE (numero=@p1 AND roll_id=@p2)";
                    public static string SQL_QUERY_UPDATE_ROLLID = "UPDATE rolls_details SET roll_id=@p3 WHERE (numero=@p1 AND product_id=@p2)";
                    public static string SQL_QUERY_UPDATE_ORDEN_PRODUCCION = "UPDATE orden_corte SET fecha=@p2,fecha_produccion=@p3,lastupdate=@p4,step=@p5 WHERE numero=@p1";
                    public static string SQL_QUERY_DELETE_ORDEN_ROLLDETAILS = "DELETE rolls_details WHERE numero=@p1";
                    public static string SQL_QUERY_UPDATE_ROLLSDETAILS_RENGLON = "UPDATE rolls_details SET splice=@p3,code_person=@p4,status=@p5,width=@p6,large=@p7,msi=@p8,roll_id=@p9 WHERE (numero=@p1 AND unique_code=@p2)";
                    public static string SQL_QUERY_SELECT_GETDATA_UNIQUE_CODE = "SELECT * FROM (SELECT numero, product_id, product_name, roll_number, width, large, msi, splice, roll_id, code_person, status, unique_code, 'M' AS tipo_mov " +
                    "FROM rolls_details WHERE disponible = 1 UNION SELECT numero, product_id, product_name, roll_number, width, large, msi, splice, roll_id, code_person, status, unique_code, 'I' AS tipo_mov FROM RollsInic WHERE disponible = 1 ) " +
                    "T WHERE T.unique_code=@p1";
                    public static string SQL_QUERY_SELECT_GETDATA_CODE_RC = "SELECT code_RC FROM producto WHERE product_id=@p1";
                    public static string SQL_QUERY_UPDATE_ROLLID_DISPONIBILIDAD = "UPDATE OrdenRecepcion SET disponible=0 WHERE Roll_Id=@p1";
                    public static string SQL_QUERY_UPDATE_ROLLID_DISPONIBILIDAD_INITIAL = "UPDATE MasterInic SET disponible=0 WHERE Roll_Id=@p1";

                    public static string SQL_QUERY_UPDATE_UNIQUE_CODE = "UPDATE rolls_details SET disponible=0 WHERE unique_code=@p1";

                    public static string SQL_QUERY_SELECT_VERIFIFY_REPEAT_OC = "SELECT count(*) FROM orden_corte WHERE numero=@p1";
                    public static string SQL_QUERY_DELETE_UNIQUE_CODE = "DELETE FROM rolls_details WHERE unique_code=@p1";
                    public static string SQL_QUERY_PROCESAR_ORDEN_OC = "UPDATE orden_corte SET Procesado=1 WHERE numero=@p1";
                    public static string SQL_QUERY_ANULAR_ORDEN_OC = "UPDATE orden_corte SET anulada=1 WHERE numero=@p1";
                    public static string SQL_QUERY_ADD_DATOS_RENDIMIENTO_MASTER = "INSERT INTO Rendim (WidRollosMax1,nVueltasMax1,CantRollosMax1,nVueltasReal1,CantRollosReal1,RollosSobran1,WidResidual1,LenResidual1,MsiResidual1,Tabla1,WidRollosMax2,nVueltasMax2,CantRollosMax2,nVueltasReal2,CantRollosReal2,RollosSobran2,WidResidual2,LenResidual2,MsiResidual2,Tabla2,numero_oc) VALUES (@P1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11,@p12,@p13,@p14,@p15,@p16,@p17,@p18,@p19,@p20,@p21)";
                    public static string SQL_QUERY_SELECT_DATOS_RENDIMIENTO_MASTER = "SELECT WidRollosMax1,nVueltasMax1,CantRollosMax1,nVueltasReal1,CantRollosReal1,RollosSobran1,WidResidual1,LenResidual1,MsiResidual1,Tabla1,WidRollosMax2,nVueltasMax2,CantRollosMax2,nVueltasReal2,CantRollosReal2,RollosSobran2,WidResidual2,LenResidual2,MsiResidual2,Tabla2,numero_oc FROM rendim WHERE numero_oc=@p1";
                    public static string SQL_QUERY_INSERT_ITEMS_CORTES = "INSERT INTO Cortes (num,width,lenght,msi,orden) VALUES (@P1,@p2,@p3,@p4,@p5)";
                    public static string SQL_QUERY_SELECT_ITEMS_CORTES = "SELECT num,width,lenght,msi,orden FROM Cortes WHERE orden=@p1";
                    public static string SQL_QUERY_SELECT_UNIQUE_CODE_LIST = "SELECT product_id,roll_number,unique_code,splice,case when width=width_c then width else width-width_c end as width,large=large-lenght_c,product_name,roll_id,msi," +
                        "code_person,status FROM rolls_details WHERE disponible = 1 ORDER BY unique_code";
                    public static string SQL_UPDATE_INVENTARIO_MASTER = "UPDATE ordenRecepcion SET width_c = @p2 ,lenght_c = lenght_c + @p3 WHERE roll_id = @p1";
                    public static string SQL_UPDATE_INVENTARIO_MASTER_WITH_INITIAL = "UPDATE MasterInic SET width_c = @p2 ,lenght_c = lenght_c + @p3 WHERE roll_id = @p1";
                    public static string SQL_UPDATE_INVENTARIO_RC = "UPDATE rolls_details SET width_c = @p2 ,lenght_c = lenght_c + @p3 WHERE unique_code = @p1";
                    public static string SQL_UPDATE_DOCUMENT_STATE = "UPDATE orden_corte SET step=@p2,lastupdate=@p3 WHERE numero=@p1";
                    public static string SQL_UPDATE_AUTHORIZE_OC = "UPDATE orden_corte SET fecha_autorize=@p2,ToAutorize=@p3,Notes=@p4,CloseDocument=@p5,Step=4 WHERE numero=@p1";
                    public static string SQL_UPDATE_DISPO_ROLLS_OC = "UPDATE rolls_details SET disponible=@p2 WHERE numero=@p1";
                    public static string SQL_SELECT_CHECK_MASTER_DOCUMENT = "SELECT count(*) FROM orden_corte WHERE rollid_1=@p1 OR rollid_2=@p1";
                    public static string SQL_MARK_MASTER_INIC = "UPDATE MasterInic SET master_load=1,doc_oc=@p2 WHERE roll_id=@p1";
                    public static string SQL_MARK_MASTER_RECEP = "UPDATE OrdenRecepcion SET master_load=1,doc_oc=@p2 WHERE Roll_Id=@p1";
                }
                public class DESPACHOS
                {
                    public static string SQL_SELECT_DESPACHOS_HEADER = "SELECT numero,fecha,customer_id,person_contact,vendor_id,transport_id,chofer_id,placas_id,packing,orden_trabajo,orden_compra,subtotal,porc_itbis,itbis,total$rd FROM despacho";
                    public static string SQL_SELECT_DESPACHOS_DETAILS = "SELECT numero,product_id,cant,unid_id,width,lenght,msi,ratio,kilo_rollo,precio,total_renglon,total_pie_lin,kilo_total FROM item_despacho";
                    public static string SQL_SELECT_CUSTOMERS = "SELECT Customer_ID,Customer_Name,Customer_Category,Customer_Dir,Customer_Email,Anulado  FROM customer";
                    public static string SQL_SELECT_VENDEDORES = "SELECT vendor_id,vendor_name FROM vendedor";
                    public static string SQL_SELECT_TRANSPORTE = "SELECT transport_id,transport_name FROM transporte";
                    public static string SQL_SELECT_CHEFERES = "SELECT chofer_id,chofer_name FROM chofer";
                    public static string SQL_SELECT_CAMION = "SELECT placas_id,camion_name FROM camion";
                    public static string SQL_SELECT_PRODUCTOS = "SELECT product_id,product_name,masterRolls,Resmas,Graphics FROM producto";
                    public static string SQL_INSERT_HEADER_ORDEN_DESPACHO = "INSERT INTO despacho (numero,fecha,customer_id,person_contact,vendor_id,transport_id,chofer_id,placas_id,packing,orden_trabajo,orden_compra,subtotal,itbis,total$rd) VALUES (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11,@p12,@p13,@p14)";
                    public static string SQL_INSERT_HEADER_DETAILS_DESPACHO = "INSERT INTO item_despacho (numero,product_id,cant,unid_id,width,lenght,msi,ratio,kilo_rollo,precio,total_renglon,total_pie_lin,kilo_total) VALUES (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11,@p12,@p13)";
                    public static string SQL_INSERT_UNIQUECODE_LIST_DESPACHO = "INSERT INTO rcdespacho (conduce,unique_code,product_id,roll_number,width,lenght,msi,roll_id,splice) VALUES (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9)";
                    public static string SQL_SELECT_UNIQUECODE_DETAILS_DESPACHO = "select a.product_id,b.Product_Name,a.roll_number,a.width,a.lenght,a.msi,a.splice,a.roll_id,a.unique_code from rcdespacho a left join producto b on a.product_id=b.Product_ID where a.conduce=@p1";
                    public static string SQL_QUERY_SELECT_GET_RATIO_PRODUCTS = "SELECT ratio FROM producto WHERE product_id=@p1";
                    public static string SQL_UPDATE_UNIQUE_CODE_FALSE = "UPDATE rolls_details SET disponible=0 WHERE unique_code=@p1";
                    public static string SQL_UPDATE_GRAPHICS_MOV_DISPOFALSE = "UPDATE OrdenRecepcion SET disponible=0 WHERE roll_id=@p1";
                    public static string SQL_UPDATE_GRAPHICS_INI_DISPOFALSE = "UPDATE GraphicsInic SET disponible=0 WHERE roll_id=@p1";
                    public static string SQL_UPDATE_UNIQUE_CODE_FALSE_INITIAL = "UPDATE RollsInic SET disponible=0 WHERE unique_code=@p1";
                    public static string SQL_UPDATE_INVENTORY_HOJAS_MOVIM_COMPLETE = "UPDATE OrdenRecepcion SET disponible=0,paletpag_c=palet_pag WHERE roll_id=@p1 and resma=1";
                    public static string SQL_UPDATE_INVENTORY_HOJAS_COMPLETE_INITIAL = "UPDATE HojasInic SET disponible=0,paletpag_c=palet_pag WHERE roll_id=@p1 and resma=1";
                    public static string SQL_UPDATE_INVENTORY_HOJAS_MOVIM_PARCIAL = "UPDATE OrdenRecepcion SET paletpag_c=paletpag_c+@p2 WHERE roll_id=@p1 and resma=1";
                    public static string SQL_UPDATE_INVENTORY_HOJAS_PARCIAL_INITIAL = "UPDATE HojasInic SET paletpag_c=paletpag_c+@p2 WHERE roll_id=@p1 and resma=1";
                    public const string SQL_INSERT_DATA_PALET_DESPACHO = "INSERT INTO Paleta (numero,number_palet,medida,contenido,kilo_neto,kilo_bruto) VALUES(@p1, @p2, @p3, @p4, @p5, @p6)";
                    public const string SQL_SELECT_DATA_PALET_DESPACHO = "SELECT number_palet,medida,contenido,kilo_bruto,kilo_neto,numero FROM Paleta WHERE numero=@p1";
                    public const string SQL_DELETE_DATA_PALET_DESPACHO = "DELETE Paleta WHERE numero=@p1";
                }
                public class INVENTARIO
                {
                    public static string SQL_INSERT_INVENTARIO_SAVE_INICIALES = "INSERT INTO iniciales (product_id,cantidad,width,lenght,msi,ubic,documento) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7)";
                    public static string SQL_SELECT_INVENTARIO_INICIALES = "SELECT a.product_id,b.Product_Name,case when b.MasterRolls = 1 then 'Master' when b.rollo_cortado = 1 then 'Rollo Cortado' when b.Graphics = 1 then 'Graphics' when b.Resmas = 1 then 'Hojas' else 'sin tipo' end as tipo,cantidad, width,lenght,msi,ubic,documento FROM iniciales a LEFT JOIN producto b ON a.product_id= b.Product_ID ";
                    public static string SQL_SELECT_INVENTARIO_QUERY_MASTER = "SELECT a.Product_ID,a.Product_Name,case when a.MasterRolls = 1 then 'Master' when a.rollo_cortado = 1 then 'Rollo Cortado' when a.Graphics = 1 then 'Graphics' when a.Resmas = 1 then 'Hojas' else 'sin tipo' end as tipo,ISNULL((SELECT sum(cantidad) from iniciales b where a.Product_ID = b.product_id),0) as cant_ini,CASE WHEN a.MasterRolls=1 or a.Resmas=1 or a.Graphics= 1 THEN " +
                    "ISNULL((SELECT CASE WHEN b.master= 1 THEN count(*) ELSE SUM(b.palet_cant) END FROM OrdenRecepcion b where a.Product_ID = b.Part_Number GROUP BY b.Part_Number, b.master),0) ELSE ISNULL((select count(*) from rolls_details b where b.product_id = a.Product_ID group by b.product_id),0) END AS cant_ENT,CASE WHEN a.MasterRolls=1 THEN ISNULL((SELECT CASE WHEN b.master= 1 THEN COUNT(*) END FROM OrdenRecepcion b where a.Product_ID = b.Part_Number AND b.disponible= 0 " +
                    "GROUP BY b.Part_Number, b.master),0) WHEN a.Resmas=1 OR a.Graphics= 1 THEN ISNULL((SELECT sum(cant) from item_despacho b where a.Product_ID= b.product_id group by b.product_id),0)  WHEN a.rollo_cortado=1 THEN 0 END AS cant_sal FROM producto a";
                    public static string SQL_QUERY_ENTRADAS_MASTER_WHERE_PRODUCT_ID = "SELECT a.OrderPurchase,a.Part_Number,a.Width,a.Lenght,a.Roll_Id,a.Proveedor_Id,a.Ubicacion," +
                    "a.Core,a.Splice,a.Anulado,a.fecha_reg,a.hora_reg,a.fecha_pro,a.master,a.resma,a.graphics,a.embarque,a.palet_num,a.palet_cant,a.palet_pag,a.num_sincro,a.registro_movil," +
                    "a.disponible,a.width_metros,a.lenght_metros,a.fecha_recep,b.Proveedor_Name,ISNULL((select sum(case rollid_2 when '' then util1_real_lenght+decartable1_pies else 0 end+util2_real_lenght+descartable2_pies) from orden_corte b where b.rollid_1=a.Roll_Id or b.rollid_2=a.Roll_Id),0) as consumo FROM OrdenRecepcion a left join Provider b on a.Proveedor_Id=b.Proveedor_ID WHERE part_number=@p1";
                    public static string SQL_QUERY_ENTRADAS_ROLLO_CORTADO_WHERE_PRODUCT_ID = "SELECT a.numero,a.Procesado,a.anulada,a.fecha,a.fecha_produccion,b.product_id,b.product_name," +
                    "b.disponible,b.roll_number,b.unique_code,b.width,b.large,b.msi,b.splice,b.code_person,b.roll_id,b.status FROM orden_corte a left join rolls_details b on a.numero = b.numero " +
                    "where b.product_id=@p1";
                    public static string SQL_QUERY_SALIDAS_ROLLOS_CORTADOS_WHERE_PRODUCT_ID = "SELECT a.conduce,c.fecha,c.customer_id,d.Customer_Name," +
                    "a.unique_code,a.product_id,b.Product_Name,a.roll_number,a.width,a.lenght,a.msi,splice,roll_id FROM rcdespacho a " +
                    "left join producto b on a.product_id=b.Product_ID left join despacho c on a.conduce = c.numero " +
                    "left join Customer d on c.customer_id= d.Customer_ID";
                    public static string SQL_SELECT_SALIDAS_MASTER = "SELECT numero,fecha,rollid_1,CASE rollid_2 WHEN '' THEN util1_real_width ELSE 0 END AS util1_real_width,CASE rollid_2 WHEN '' THEN util1_real_lenght ELSE 0 END AS util1_real_lenght,lenght_1,CASE rollid_2 WHEN '' THEN decartable1_pies ELSE 0 END AS decartable1_pies ,CASE rollid_2 WHEN '' THEN (util1_real_lenght+decartable1_pies) ELSE 0 END AS total_con,CASE rollid_2 WHEN '' THEN cant_rollos ELSE 0 END AS cant_rollos,util2_real_width,util2_real_lenght,width_2,lenght_2,descartable2_pies,(util2_real_lenght+descartable2_pies) AS total_con2 FROM orden_corte WHERE rollid_1=@p1 OR rollid_2=@p1";
                    public static string SQL_INSERT_DATA_RESERVA = "INSERT reserva (transac,orden_t,orden_s,fecha_reserva,fecha_entrega,id_cust,commentary,id,tipo_product) VALUES (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9)";
                    public static string SQL_TRANSACT_DATA_RESERVA = "SELECT COUNT(DISTINCT transac)+1 FROM reserva";
                    public static string SQL_MARK_RESERVA_MASTER = "UPDATE MasterInic SET status='Reservado' WHERE roll_id=@p1";
                    public static string SQL_MARK_RESERVA_HOJAS = "UPDATE HojasInic SET status='Reservado' WHERE roll_id=@p1";
                    public static string SQL_MARK_RESERVA_GRAF = "UPDATE GraphicsInic SET status='Reservado' WHERE roll_id=@p1";
                    public static string SQL_MARK_RESERVA_ROLLS = "UPDATE RollsInic SET status='Reservado' WHERE unique_code=@p1";
                    public static string SQL_SELECT_INFO_RESERVA = "SELECT transac,orden_s,orden_t,fecha_entrega,fecha_reserva,id_cust,b.Customer_Name,a.commentary FROM Reserva a LEFT JOIN Customer b on a.id_cust = b.Customer_ID WHERE id=@p1";
                    public static string SQL_DELETE_ITEM_RESERVA = "DELETE Reserva WHERE id=@p1";
                    public static string SQL_UPDATE_ITEM_UNMARK_RESERVA3 = "UPDATE RollsInic SET status='Ok.' WHERE unique_code=@p1";
                    public static string SQL_LIST_ID_ITEM_RESERVA = "SELECT id FROM reserva WHERE transac=@p1";
                    public static string SQL_DELETE_DOCUMENT_RESERVA = "DELETE Reserva WHERE transac=@p1";
                    public static string SQL_GETDATA_ROLLS_FROMRC = "SELECT * FROM (SELECT unique_code,product_id,product_name,width,large,msi,'I' AS tipo FROM RollsInic " +
                    "UNION SELECT unique_code,product_id,product_name,width,large,msi,'M' AS tipo FROM rolls_details) T WHERE T.unique_code=@p1";
                    public static string SQL_UPDATE_UBICATION_ROLLS_INIC = "UPDATE RollsInic SET ubic=@p2 WHERE unique_code=@p1";
                    public static string SQL_UPDATE_UBICATION_ROLLS_ORDEN = "UPDATE rolls_details SET ubic=@p2 WHERE unique_code=@p1";
                }
                public class DEVOLUCION 
                {
                    public static string SQL_SELECT_DEVOLUCIONES_SELECT_HEADER = "SELECT numero,fecha,customer_id,razon,doc_status FROM Devoluciones";
                    public static string SQL_SELECT_DEVOLUCIONES_SELECT_ITEMSROWS = "SELECT numero,product_id,cantidad,roll_id,tipo,width,lenght,msi,sw FROM Item_Devol";
                    public static string SQL_INSERT_HEADER = "INSERT INTO Devoluciones (numero, fecha, customer_id, razon, doc_status) values(@p1, @p2, @p3, @p4, @p5)";
                    public static string SQL_INSERT_ITEMROWS = "INSERT INTO Item_Devol (numero, product_id, cantidad, roll_id, tipo, width, lenght, msi, sw) values(@p1, @p2, @p3, @p4, @p5, @p6, @p7, @p8, @p9)";

                    public const string SQL_CHECK_ID_MASTER_DEVOL = "SELECT * FROM MasterInic WHERE (roll_id=@p1 AND part_number=@p2 AND disponible=0)";
                    public const string SQL_CHECK_ID_ROLL_DEVOL = "SELECT * FROM  RollsInic WHERE (unique_code=@p1 AND product_id=@p2 AND disponible=0)";
                    public const string SQL_CHECK_ID_GRAPHICS_DEVOL = "SELECT * FROM GraphicsInic WHERE (roll_id=@p1 AND part_number=@p2 AND disponible=0)";
                    public const string SQL_CHECK_ID_HOJAS_DEVOL = "SELECT * FROM HojasInic WHERE (roll_id=@p1 AND part_number=@p2)";


                    public const string SQL_GETDATA_ID_ROLL_DEVOL = "SELECT width,large,msi FROM RollsInic WHERE (unique_code=@p1 AND product_id=@p2 AND disponible=0)";
                    public const string SQL_GETDATA_ID_GRAPHICS_DEVOL = "SELECT width,Lenght,0 FROM GraphicsInic WHERE (roll_id=@p1 AND Part_Number=@p2 AND disponible=0)";
                    public const string SQL_GETDATA_ID_HOJAS_DEVOL = "SELECT palet_cant,palet_pag,paletpag_c FROM HojasInic WHERE (roll_id=@p1 AND Part_Number=@p2)";



                    public const string SQL_UPDATE_INVENTORY_MASTER_DEVOL = "UPDATE MasterInic SET disponible=@p2 WHERE (roll_id=@p1)";
                    public const string SQL_UPDATE_INVENTORY_ROLL_DEVOL = "UPDATE RollsInic SET width=@p2,large=@p3,msi=@p4,disponible=@p5 WHERE (unique_code=@p1)";
                    public const string SQL_UPDATE_INVENTORY_GRAPHICS_DEVOL = "UPDATE GraphicsInic SET width=@p2,lenght=@p3,disponible=@p5 WHERE (roll_id=@p1)";
                    public const string SQL_UPDATE_INVENTORY_HOJAS_DEVOL = "UPDATE HojasInic SET paletpag_c=@p4,disponible=1 WHERE (roll_id=@p1)";

                    public const string SQL_ANULAR_DOCUMENTO_DEVOL = "UPDATE devoluciones SET doc_status=1 WHERE (numero=@p1)";

                }
            }
        }
        public class ERROR_MESSAGES
        {
            public class ERROR_SQL 
            {
                public static string ERROR_MESSAGE_SQLCONNECT= "Error al conectarse a la base de datos del sistema.";
                public static string ERROR_MESSAGE_SQLDISCONNECT = "Error al desconectarse de la base de datos del sistema.";
            }
            public class DEVOLUCIONES 
            {
                public static string MESSAGE_SELECT_DEV_ERROR_HEADER="Error al cargar los datos del encabezado de las devocuciones";
                public static string MESSAGE_SELECT_DEV_ERROR_ITEMROWS = "Error al cargar los items de la tabla de renglones de devoluciones.";
                public static string MESSAGE_ERROR_INSERT_HEADER = "Error al insertar registro en el Encabezado de la devolucion a clientes.";
                public static string MESSAGE_ERROR_INSERT_ITEMROWS = "Error al insertar registro en el Detalle de la devolucion a clientes.";
                public static string MESSAGE_ERROR_ANULAR_DOC = "Error al tratar de anular documentos de devoluciones de clientes.";
                public static string MESSAGE_ERROR_GETDATA_UNIQUE = "Error al tratar de obtener la informacion del ancho y largo del producto.";
                public static string MESSAGE_ERROR_UPDATE_INVENTARY = "Error al actualizar los inventarios de los documentos de devoluciones.";
            }
            public class INVENTARIO
            {
                public static string MESSAGE_INSERT_INICIALES_ERROR = "Error al tratar de grabar la data de los iniciales.";
                public static string MESSAGE_SELECT_INICIALES_ERROR = "Error al de cargar la data de los iniciales.";
                public static string MESSAGE_CARGAR_INVENTARIO_ERROR = "ERROR AL CARGAR LOS INVENTARIO DEL SISTEMA.";
                public static string MESSAGE_CARGAR_MOVIMIENTO_MASTER = "Error al cargar los movimiento de inventarios tipo master...";
                public static string MESSAGE_CARGAR_ENTREDAS_ROLLO_CORTADO = "Error al cargar las entredas de inventarios tipo ROLLO CORTADO...";
                public static string MESSAGE_CARGAR_SALIDAS_ROLLO_CORTADO = "Error al cargar las salidas de inventarios tipo ROLLO CORTADO...";
                public static string MESSAGE_ERROR_SALIDAS_MASTER = "Error al tratar de cargar la informacion de las salidas de los master en el inventario...";
                public static string MESSAGE_ERROR_TRANSAC_RESERVAS = "Error al obtener el numero de transaccion en las reservas de productos.";
                public static string MESSAGE_ERROR_INFO_RESERVAS = "Error al cargar la informacion de reserva de productos.";
                public static string MESSAGE_ERROR_DELETE_ITEM_RESERVAS = "Error al tratar de borra item de reserva de productos.";
                public static string MESSAGE_ERROR_DELETE_DOCUMENT_RESERVAS = "Error al tratar de borra documentos reserva de productos.";
                public static string MESSAGE_ERROR_UBICATION_FROMRC = "Error al cambiar la ubicacion en el almacen de los rollos cortados.";

            }
            public class MODULO_PRODUCTOS
            {
                public static string MESSAGE_SELECT_LOADPRODUCTOS_FAIL = "error al cargar la tabla de productos...error code:";
                public static string MESSAGE_ADD_PRODUCTS_ERROR = "Error al crear productos...Error Code:";
                public static string MESSAGE_UPDATE_PRODUCTS_ERROR = "Error al modificar producto...Error Code:";
            }
            public class MODULO_PROVEEDORES
            {
                public static string MESSAGE_SELECT_LOADPROVEEDORES_FAIL = "Error al cargar la tabla de providers...error code: ";
            }
            public class MODULO_RECEPCIONES
            {
                public static string MESSAGE_TEXT_RECEPCIONES_ERROR_ADD_DOCUMENTS = "Error al incluir ordenes de recepcion de materia prima(MASTER)..error code:";
                public static string MESSAGE_INSERT_RECEPCIONES_OK = "Se registraron los datos de la recepcion correctamente.";
                public static string MESSAGE_INSERT_RECEPCIONES_FAIL = "Error al tratar de registrar los datos de las recepciones de materia prima.";
                public static string MESSAGE_UPDATE_RECEPCIONES_OK = "Se actualizo la informacion de la orden de recepcion";
                public static string MESSAGE_UPDATE_RECEPCIONES_FAIL = "Error al tratar de actualizar los datos de la orden de recepcion";
                public static string MESSAGE_SELECT_LOADRECEPCIONES_FAIL = "Error al tratar de traer los datos de las recepciones de materia prima.";

            }
            public class CUSTOMERS
            {
                public static string MESSAGE_SELECT_LOAD_CUSTOMERS_FAIL = "Error al tratar de cargas los clientes al sistema ERROR: ";
                public static string MESSAGE_ERROR_GETLISTCUSTOMERS = "Ha ocurrido un error al tratar de traer la lista de clientes del sistema.";
            }
            public class PRODUCCION
            {
                public static string MESSAGE_LOAD_ROLLOS_CORTADOS_ERROR_FAIL = "Error al cargar la lista de los rollos cortados. error code:";
                public static string MESSAGE_ADD_ORDEN_ERROR_FAIL_HEADER = "Error al tratar de grabar el encabezado de la orden de produccion";
                public static string MESSAGE_ADD_ORDEN_ERROR_FAIL_DETAILS = "Error al tratar de grabar el detalle de la orden de produccion";
                public static string MESSAGE_ADD_ORDEN_ERROR_FAIL_ROLLS_INIC = "Error al tratar de grabar  los roll cordatos para el inventario inicial";

                public static string MESSAGE_LOAD_ROLLID_ERROR_FAIL = "Error al cargar los roll id de la materia prima";
                public static string MESSAGE_UPDATE__ERROR_HEADER = "Error al modificar el encabezado de la orden de produccion";
                public static string MESSAGE_DELETE_ORDER_ROLLSDETAIL = "Error al tratar de eliminar informacion de los rollos cortados...";
                public static string MESSAGE_UPDATE_ERROR_ORDER_ROLLSDETAIL = "ERROR AL ACTUALIZAR LA DATA DE LOS ROLLOS CORTADOS...";
                public static string MESSAGE_UPDATE_ERROR_UPDATE_ROLLID = "Error al actualizar la disponibilidad de los numeros ROLL ID.";
                public static string MESSAGE_UPDATE_ERROR_UPDATE_UNIQUE_CODE = "Error al actualizar la disponibilidad de los numeros UNIQUE CODE.";
                public static string MESSAGE_UPDATE_PROCESAR_ORDEN_OC = "Error al procesar documento de orden de corte";
                public static string MESSAGE_UPDATE_ANULAR_ORDEN_OC = "Error al Anular documento de orden de corte";
                public static string MESSAGE_ADD_RENDIM_MASTER = "Error al Anular documento de orden de corte";
                public static string MESSAGE_ADD_ITEMS_CORTES = "Error al intentar grabar la informacion de la dimension de los cortes...";
                public static string MESSAGE_SELECT_ITEMS_CORTES = "Error al cargar los datos de la dimension de los cortes...";
                public static string MESSAGE_SELECT_UNIQUE_CODE_TOLIST = "Error al cargar la data de los RC (Unique code) de la base de datos...";
                public static string MESSAGE_UPDATE_INVENTARIO_MASTER = "Error al actualizar los inventario de master (Material remanente)...";
                public static string MESSAGE_UPDATE_INVENTARIO_RC = "Error al actualizar los inventario de unique code (REBOBINADO)...";
                public static string MESSAGE_ERROR_AUTHORIZE_OC = "Error al tratar de actualizar la orden de corte (Proceso: Autorización)";

            }
            public class DESPACHOS
            {
                public static string MESSAGE_SELECT_ERROR_LOAD_PRODUCTS = "Error al tratar de cargar los productos.";
                public static string MESSAGE_SELECT_ERROR_LOAD_CHOFERES = "Error al tratar de cargar los choferes.";
                public static string MESSAGE_SELECT_ERROR_LOAD_CAMIONES = "Error al tratar de cargar los camiones.";
                public static string MESSAGE_SELECT_ERROR_LOAD_TRANSPORTE = "Error al tratar de cargar los transportes.";
                public static string MESSAGE_SELECT_ERROR_LOAD_VENDEDOR = "Error al tratar de cargar los vendedores.";
                public static string MESSAGE_SELECT_ERROR_LOAD_CUSTOMERS = "Error al tratar de cargar los clientes en el modulo de despacho.";
                public static string MESSAGE_SELECT_ERROR_LOAD_HEADER_DESPACHOS = "Error al tratar de cargar los encabezados de los despachos.";
                public static string MESSAGE_SELECT_ERROR_LOAD_DETAILS_DESPACHOS = "Error al tratar de cargar los detalle de los despachos.";
                public static string MESSAGE_INSERT_ERROR_ADD_HEADER_DESPACHOS = "Error al tratar de insertar el encabezado de despacho.";
                public static string MESSAGE_INSERT_ERROR_ADD_DETAILS_DESPACHOS = "Error al tratar de insertar el detalle en la orden de despacho.";
                public static string MESSAGE_INSERT_UNIQUECODE_ADD_DETAILS_DESPACHOS = "Error insertar los detalle de los unique code en el despacho.";
                public static string MESSAGE_SELECT_UNIQUECODE_DETAILS_DESPACHOS = "Error al tratar de traer la data ";
                public static string MESSAGE_UPDATE_UNIQUECODE_DISPOFALSE = "Ha ocurrido un error al tratar de actualizar los unique code para el inventario.";
                public static string MESSAGE_UPDATE_graphics = "Ha ocurrido un error al tratar de actualizar los inventario. tipo de producto graphics.";
                public static string MESSAGE_SELECT_ADDPALET = "Error al tratar de Agregar los datos de la Paleta.";
                public static string MESSAGE_SELECT_GETDATAPALET = "Error al traer la informacion del detalle de la paleta.";
            }
        }
        public class PATH_FILES
        {
            public static string FILE_TXT_MATERIA_PRIMA = @"\Users\npino\Documents\RITRAMA\RitramaAPP\data\recepciones.txt";
            public static string FILE_TXT_DATA_ETIQUETA = @"\Etiquetas\data_orden_corte.txt";
            public static string FILE_TXT_DATA_PICKING_DESPACHO = @"\Users\npino\Documents\RITRAMA\RitramaAPP\data\picking.txt";
            public static string FILE_TXT_DATA_CANT_INICIALES = @"\Users\npino\Documents\RITRAMA\RitramaAPP\data\iniciales.txt";
            public static string PATH_DATA_REPORT_ORDEN_CORTE = @"\Reports\Orden_Corte.rpt";
            public static string PATH_DATA_IMPORT_EXCEL_RECEPCIONES = @"\Users\npino\Desktop\ritrama\";
            public static string PATH_REPORTS_FORMAT_CONDUCE = @"\Reports\Format_Despacho.rpt";
            public static string PATH_REPORTS_DETALLE_RC = @"\Reports\detalle_RC.rpt";
            public static string PATH_REPORTS_FORMAT_CONDUCE_SP = @"\Reports\Format_Despacho_sinprecio.rpt";
            public static string PATH_REPORTS_DETALLE_PALETA = @"\Reports\detalle_Paleta.rpt";
            public static string PATH_REPORTS_RESERVA_PRODUCTOS = @"\Reports\Report_reserva.rpt";
        }
        public class CONSTANTES
        {
            public static Double FACTOR_METROS_PULDADAS = 39.3701;
            public static Double FACTOR_METROS_PIES = 3.28084;
            public static Double FACTOR_PULGADAS_METROS = 0.0254;
            public static Double FACTOR_PIES_METROS = 0.3048;
            public static Double FACTOR_CALCULO_MSI = 0.012;
            public static Double FACTOR_MM_PULGADAS = 0.0393701;
            public const string TIPO_MASTER = "Master";
            public const string TIPO_ROLL = "Rollo Cortado";
            public const string TIPO_GRAP = "Graphics";
            public const string TIPO_HOJA = "Hojas";
            public const string OPTION_MENU_REPORTE1 = "Resporte de Reserva de Productos";
            public const string RESERVA_FLAG_TRUE = "Reservado";
            public const string DOCUMENT_OC_STEP1 = "CARGADO";
            public const string DOCUMENT_OC_STEP2 = "EN PRODUCCION";
            public const string DOCUMENT_OC_STEP3 = "ETIQUETADO";
            public const string DOCUMENT_OC_STEP4 = "APROBADO";
            public const string DOCUMENT_OC_STEP5 = "CERRADO";
            public const string DOCUMENT_OC_STEP0 = "SIN ESTADO";



        }

    }
}
