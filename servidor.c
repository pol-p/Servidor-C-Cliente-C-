#include <string.h>
#include <unistd.h>
#include <stdlib.h>
#include <sys/types.h>
#include <sys/socket.h>
#include <fcntl.h>
#include <netinet/in.h>
#include <stdio.h>
#include <errno.h>

#define MAX_BUFF 512
#define PORT 9000

void error(const char *msg){
    perror(msg);
    exit(EXIT_FAILURE);
}

int main(int argc, char **argv){
    int sock_listen, sock_conn, ret;
    struct sockaddr_in serv_adr;
    char buff[MAX_BUFF];
    
    //Abrir el socket
    if ((sock_listen = socket(AF_INET, SOCK_STREAM, 0)) < 0){
            error("Error al crear el socket");
    }

    //COnfiguracion del server_addr
    memset(&serv_adr, 0, sizeof(serv_adr));
    serv_adr.sin_family = AF_INET;
    serv_adr.sin_addr.s_addr = htonl(INADDR_ANY);
    serv_adr.sin_port = htons(PORT);

    //Asignar ip y puerto al socket
    if (bind(sock_listen, (struct sockaddr *) &serv_adr, sizeof(serv_adr)) < 0){
        error("Error al bind");
    }

    //Limitar la cola de espera al servidor
    if (listen(sock_listen, 10) < 0){
        error("Error en Listen");
    }
    printf("[!] Servidor escuchando en el puerto %d...\n", PORT);
    char *token;
    //Bucle infinito
    for(;;){
        //Aceptar conexion del exterior
        sock_conn = accept(sock_listen, NULL, NULL);
        if (sock_conn < 0){
            error("Error al aceptar la conexion con el socket");
        }
        for(;;){
            ret = read(sock_conn, buff, sizeof(buff) - 1);
            if (ret < 0){
                error("Error al leer del socket");
            }

            buff[ret] = '\0';
            token = strtok(buff, "/");
            if(strcmp(token, "ExIt") == 0){
                break;
            }
            printf("Mensaje recibido: %s\n", buff);            
        }
    }

    close(sock_listen);
    return 0;
}